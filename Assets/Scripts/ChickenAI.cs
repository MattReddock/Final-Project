using System.Collections;
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

    private GameObject player;
    public float runAwayDistance = 6.0f;

    private bool running;
 
    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
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
            }

        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < runAwayDistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);
            running = true;
        }
        else
        {
            running = false;
        }
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
