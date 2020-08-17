using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public float runAwayDistance = 8.0f;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < runAwayDistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);            
        }
        
    }

}
