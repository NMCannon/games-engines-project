using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 18f;
    public float gravity = -22f;
    public float jumpHeight = 6f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Return true if object touching ground layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If player is touching ground and not moving vertically
        if(isGrounded && velocity.y <0)
        {
            // Reset the velocity to keep player grounded
            velocity.y = -2f;
        }

        // Get wasd input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Vector for player movement
        Vector3 move = transform.right * x + transform.forward * z;

        // Move player with character controller
        controller.Move(move * speed * Time.deltaTime);

        // If space is pressed and player is touching ground layer
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            // Lift player up by amount needed to reach jumpHeight
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity to player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
