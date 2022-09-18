using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    private GameObject player;
    private float timeBtwBites;
    public float startTimeBtwBites;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public int enemyHealth = 2;

    public GameObject deathEffect;

    private PlayerController playerController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        // Chase();
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
        moveDirection = direction;

        //Flip();

        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }
    //Moving towards player
    private void Chase()
    {
        transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, player.transform.position)<=0.5)
        {
            if (timeBtwBites <= 0)
            {
                playerController.PlayerTakeDamage(1);
                timeBtwBites = startTimeBtwBites;
            }
            else
            {
                timeBtwBites -= Time.deltaTime;
            }
        }
    }

    //Rotating to face player
    private void RotateTowardsTarget()
    {
        
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
            transform.rotation=Quaternion.Euler(0, 0, 90);
        else
            transform.rotation=Quaternion.Euler(0, 180, 90);
    }



    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}