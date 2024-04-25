using UnityEngine;

public class Recoil : MonoBehaviour
{
    Vector3 targetPosition, currentPosition, initialGunPosition;
    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;
    [SerializeField] float kickBackZ;
    [SerializeField] float snappiness;
    [SerializeField] float returnAmount;

    void Start()
    {
        initialGunPosition = transform.localPosition;
        currentPosition = initialGunPosition;
        targetPosition = initialGunPosition;
    }

    void Update()
    {
        back();
    }

    public void recoil()
    {
        targetPosition.z -= kickBackZ;
        targetPosition += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }

    void back()
    {
        targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * snappiness);
        transform.localPosition = currentPosition;
    }
}