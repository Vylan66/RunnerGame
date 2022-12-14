using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    

    public float speed;
    public float lifeTime;
    public float distance;
    public int enemyDamage;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyController>().EnemyTakeDamage(enemyDamage);
                PlayerManager.Instance.PlayerScore += 1;
                PlayerManager.Instance.ScoreText.text = $"Score: {PlayerManager.Instance.PlayerScore}";
            }
            DestroyProjectile();
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //void AddScore()
    //{
    //    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
    //    if (hitInfo.collider != null)
    //    {
    //        if (hitInfo.collider.CompareTag("Enemy"))
    //        {
                
    //            scoreText.text = $"Score: {Score}";
    //        }
    //    }
    //}
    
        
    
}
