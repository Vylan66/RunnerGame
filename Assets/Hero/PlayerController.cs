using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    [SerializeField] private LayerMask platformsLayerMask;
    public int maxHealth = 3;
	public static int currentHealth;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

	private PlayerHealthBar playerHealthBar;

    
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = PlayerManager.Instance.PlayerHealthBar;
        //Initializing health 
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            float jumpVelocity = 15f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement_FullMidAirControl();
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        //Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement_FullMidAirControl() {
        float moveSpeed = 13;
        rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
    }

    //Defining taking dmg
    public void PlayerTakeDamage(int damage)
	{
        //Debug.Log($"PlayerTakeDamage: {damage}, currentHealth: {currentHealth}");
		currentHealth -= damage;
        if(playerHealthBar == null)
        {
            playerHealthBar = PlayerManager.Instance.PlayerHealthBar;
        }
		playerHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
	}
}


