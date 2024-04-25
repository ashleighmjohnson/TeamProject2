using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public int damage;
    BoxCollider boxCollider;

    //Animations
    public Animator anim;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Speed variable
    public float speed = 3.0f;

    // Music controller
    public EnemyMusicController musicController;

    // Enemy dead
    public AudioClip deathSound; // Sound to play when enemy dies
    public float deathAnimationLength; // Duration of the death animation

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();

    }

    void Start()
    {
        // Set the initial speed of the enemy
        agent.speed = speed;
    }

    void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
        else // Player is within sight range but outside attack range
        {
            // Switch to running animation
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsAttacking", false);
        }
        
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            anim.SetBool("IsPatrolling", true);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsAttacking", false);
        transform.LookAt(player);
    }

    // Define a flag to track whether attack music has been played
    private bool hasPlayedAttackMusic = false;

    void AttackPlayer()
    {
        // Check if the current animation state is not the attack animation
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack 1"))
        {
            // Reset the flag since the enemy is not attacking
            hasPlayedAttackMusic = false;
            // Make sure enemy doesn't move
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            anim.SetTrigger("Attack");
        }
        else // Enemy is in attack animation
        {
            // Check if attack music has not been played yet
            if (!hasPlayedAttackMusic)
            {
                // Play attack music
                musicController.PlayAttackMusic();
                // Set the flag to true to indicate that attack music has been played
                hasPlayedAttackMusic = true;
            }
        }
    }



    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Play death music
            musicController.PlayDeathMusic();
            // Delay enemy destruction until after the death sound finishes
            Invoke(nameof(KillEnemy), musicController.deathClip.length);
        }
        else
        {
            // Play hit music
            musicController.PlayHitMusic();
        }
    }

    public void KillEnemy()
    {
        // Trigger death animation
        anim.SetTrigger("Dead");

        // Play death sound
        AudioSource.PlayClipAtPoint(deathSound, transform.position);

        GetComponent<CapsuleCollider>().enabled = false;

        // Delay destruction of the enemy object until after the death animation finishes
        Destroy(gameObject, deathAnimationLength);


    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            KillEnemy();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //   var player = other.GetComponent<PlayerController>
        // Debug.Log("Hit");
    }

    //if (player != null)
    //{
    //   debug.log("Hit");
    //Add player health/knockback/whatever here
    //}
}
