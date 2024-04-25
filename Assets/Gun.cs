using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDisappearTime = 1f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private Recoil recoil;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private bool bulletSpread = false;
    public Camera playerCam;
    private int pellets = 60;
    public float range = 10f;
    private float nextFire = 0f;
    public float maxSpread = 40f;

    void Start()
    {
        recoil = GetComponent<Recoil>();
        nextFire = fireRate;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (bulletSpread)
            {
                ShotgunShoot();
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        // bullet.transform.Rotate(0, 0, 0);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletPoint.transform.forward * bulletSpeed * 100);

        if (muzzleFlash != null)
            muzzleFlash.Play();

        if (smoke != null)
            smoke.Play();

        if (recoil != null)
            recoil.recoil();

        Destroy(bullet, bulletDisappearTime);
    }
    void ShotgunShoot()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();

        if (smoke != null)
            smoke.Play();

        if (recoil != null)
            recoil.recoil();

        for (int i = 0; i < pellets; i++)
        {
            RaycastHit hitInfo;

            Vector3 randomDirection = playerCam.transform.forward +
                                      playerCam.transform.right * Random.Range(-maxSpread, maxSpread) +
                                      playerCam.transform.up * Random.Range(-maxSpread, maxSpread);

            randomDirection += playerCam.transform.forward * 0.5f;

            randomDirection.Normalize();

            if (Physics.Raycast(playerCam.transform.position, randomDirection, out hitInfo, range))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    Debug.Log("Hit GameObject: " + hitInfo.collider.name);
                    EnemyController enemy = hitInfo.collider.GetComponent<EnemyController>();
                    if (enemy != null)
                    {
                        enemy.KillEnemy();
                    }
                }
            }
            Debug.DrawRay(playerCam.transform.position, randomDirection * range, Color.red, 0.1f);
        }
    }
}
