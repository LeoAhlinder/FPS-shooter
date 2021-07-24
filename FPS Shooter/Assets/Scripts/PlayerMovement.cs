using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CC;
    public float speed = 4f;
    public LayerMask groundMask;
    float gravity = -18f;
    Vector2 velocity;
    public Transform groundCheck;
    bool isGrounded;
    float jumpHeight = 2f;
    bool IsRunning;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
        if (isGrounded && velocity.y < 0 && !IsRunning)
        {
            speed = 8f;
            velocity.y = -2f;
        }
        if (!isGrounded)
        {
            speed = 10f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CC.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        CC.Move(velocity * Time.deltaTime);

    }
}
