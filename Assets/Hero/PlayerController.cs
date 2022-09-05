using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 1f;
    [SerializeField] private float jumpHeight = 5f;
    
    public int maxHealth = 100;
	public static int currentHealth;

	public PlayerHealthBar playerHealthBar;

    private float gravity = -25f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    private long frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
        
        //Initializing health 
        currentHealth = maxHealth;
		playerHealthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;
        //Face Forward
        // Is Grounded
        isGrounded = Physics.CheckSphere(transform.position, 1f, groundLayers, QueryTriggerInteraction.Ignore);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);


      

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -1 * gravity);
        }
        

        //Gravity
        velocity.y += gravity * Time.deltaTime;

        //Vertical Velocity
        characterController.Move(velocity * Time.deltaTime);

        // //Taking damage
        // if (Input.GetKeyDown(KeyCode.Space))
		// {
		// 	TakeDamage(1);
		// }

    }

    //Defining taking dmg
    public void PlayerTakeDamage(int damage)
	{
        Debug.Log($"PlayerTakeDamage: {damage}, currentHealth: {currentHealth}");
		currentHealth -= damage;

		playerHealthBar.SetHealth(currentHealth);
	}
}
