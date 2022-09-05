using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;

    public int enemyHealth = 2;

    public GameObject deathEffect;

    public PlayerHealthBar playerHealthBar;
    public PlayerController playerController;
   

    private void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null) 
        {
            return;
        }
        if (chase == true) 
        {
            if(playerHealthBar != null) 
            {
                Chase();
            }
            
        }
            
    
        Flip();

    }

    private void Chase()
    {
        transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, player.transform.position)<=0.5)
        {
            playerController.PlayerTakeDamage(1);
        }
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
            transform.rotation=Quaternion.Euler(0, 0, 0);
        else
            transform.rotation=Quaternion.Euler(0, 180, 0);
    }
    


    public void EnemyTakeDamage (int damage)
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