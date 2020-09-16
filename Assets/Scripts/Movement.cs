using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float lowerGravity = -20f;
    public float bigJump = 4.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    Vector3 move;

    private Rigidbody rb;
    private CatchChicken caught;

    private void Start()
    {
        caught = FindObjectOfType<CatchChicken>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = (transform.right * x) + (transform.forward * z);
        move.Normalize();
        
        if (Input.anyKey)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        //Debug.Log("isGrouned = " + isGrounded);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            if(caught.hasChicken == true)
            {
                rb.mass = 0.25f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * lowerGravity);
            }
            else
            {
                rb.mass = 1f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
    public void HitEgg()
    {
        speed = 3f;
    }

    public void LeaveEgg()
    {
        speed = 12f;
    }
}

