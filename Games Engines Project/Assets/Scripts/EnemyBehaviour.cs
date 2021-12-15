using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject bulletPrefab;
    public Transform enemy_gun;
    public float bulletSpeed = 10f;
    public float lifeTime = 3f;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("fpsPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // If agent can't see player or attack, patrol
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        // If agent can see player but can't attack, chase player
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        // If agent can see player and can attack, attack player
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }


    private void Patrolling()
    {
        // If no walk point set, find one
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        // Else go to walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        // Get distance to walk point
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // Create random walk point
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Check if walk point is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Face player
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here

            // Instatiate bullet
            GameObject bullet = Instantiate(bulletPrefab);

            // Ignore collision with player's gun (parent)
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), enemy_gun.parent.GetComponent<Collider>());

            // Spawn bullet at bullet spawn position
            bullet.transform.position = enemy_gun.position;

            // Convert quaternion roation to vector3
            Vector3 rotation = bullet.transform.rotation.eulerAngles;

            // Set bullet rotation
            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

            // Project the bullet
            bullet.GetComponent<Rigidbody>().AddForce(enemy_gun.forward * bulletSpeed, ForceMode.Impulse);

            // Start Coroutine
            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    // Coroutine for destroying bullets after specified time
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // Gizmos for enemy chase and attack radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
