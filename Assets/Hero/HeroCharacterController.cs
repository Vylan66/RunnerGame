using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 1f;
    [SerializeField] private float jumpHeight = 20f;

    private float gravity = -10f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;

        //Face Forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
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

        characterController.Move(new Vector3(horizontalInput, 0, 0) * Time.deltaTime);

        if (isGrounded)
        {
            Debug.Log("Is Grounded");
        }

      

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumped");
            velocity.y += Mathf.Sqrt(jumpHeight * -1 * gravity);
        }
        // else
        // {
        //     Debug.Log("not grounded");
        // }

        //Gravity
        velocity.y += gravity * Time.deltaTime;

        //Vertical Velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
