﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    public float wanderRadius = 3.0f;
    public float wanderTimer = 5.0f;
    private float timer; 
    private Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    private GameObject player;
    public float runAwayDistance = 6.0f;

    private bool running;
    private bool walking;
 
    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        anim = GetComponent<Animator>();
        
    }
 
    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            if(!running)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);            
                agent.SetDestination(newPos);
                timer = 0;                
                Invoke("StopMovement", 1f);
                walking = true;
            }
            else
            {
                walking = false;
            }
            

        }
        

        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance < runAwayDistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);
            running = true;
            walking = false;
        }
        else
        {
            running = false;            
        }
        

        if (walking)
        {
            anim.SetBool("Walk", true);
            walking = true;            
        }
        else
        {
            anim.SetBool("Walk", false);
            walking = false;
        }

        if (running)
        {
            anim.SetBool("Run", true);
            running = true;
        }
        else
        {
            anim.SetBool("Run", false);
            running = false;
        }
    }

    void StopMovement()
    {
        walking = false;
        anim.SetBool("Walk", true);
    }
    

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;        
    }
}
