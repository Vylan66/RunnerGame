using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public EnemyController[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyController enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    
}
