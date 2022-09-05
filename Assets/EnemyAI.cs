using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject gunHitEffect;
    public GameObject bulletShotPoint;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
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
    public float projectileForce;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        transform.LookAt(player);

    }
    private void SearchWalkPoint()
    {
        transform.LookAt(player);
        //Calculate random point in range
        float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

        //Makes sure enemy doesn't walk off the map
        // if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        //     walkPointSet = true;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, bulletShotPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // public void Hit(int damage)
    // {
    //     var hitEffect = Instantiate(gunHitEffect, transform.position, Quaternion.identity);
    //     health -= damage;
    //     Destroy(hitEffect, 1);

    //     if (health <= 0) Invoke(nameof(DestroyEnemy), 0.05f);
    // }
    public void TakeDamage(int damage)
    {
        var hitEffect = Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        health -= damage;
        Destroy(hitEffect, 1);

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.05f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
}