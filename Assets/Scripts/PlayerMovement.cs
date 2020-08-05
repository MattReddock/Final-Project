using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpeed = 0.1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;
    Vector3 move;

    Vector3 PreviousFramePosition = Vector3.zero;

    public float multiplier = 0.1f;

    public bool pause = false;
    //public Animator animator;

    void Update()
    {
        if (!pause)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x) + (transform.forward * z);
            move.Normalize();

            if (Input.anyKey)
            {
                controller.Move(move * speed * Time.deltaTime);
            }


            if (move != Vector3.zero && multiplier < 1)
            {
                multiplier += 0.01f;
            }

            else if (move != Vector3.zero && multiplier >= 1)
            {
                multiplier = 1f;
            }

            else if (move == Vector3.zero && multiplier >= 0.01f)
            {
                multiplier -= 0.01f;
            }

            else if (move == Vector3.zero && multiplier <= 0.01f)
            {
                multiplier = 0.01f;
            }

            float newTimeScale = minSpeed + multiplier;

            if (newTimeScale > 1)
                newTimeScale = 1;

            if (newTimeScale < 0.1f)
                newTimeScale = 0.1f;

            Time.timeScale = newTimeScale;

            UnityEngine.Debug.Log(multiplier);


            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }



            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        
        /*if (pause)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }*/

        
    }
}
