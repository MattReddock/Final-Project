using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    public float wanderRadius = 3.0f;
    public float wanderTimer = 8.0f;
    private float timer;
    private float mineTimer;
    private Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    private GameObject player;
    public float runAwayDistance = 6.0f;

    private bool running;
    private bool walking;

    public GameObject EggPrefab;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;    

    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        anim = GetComponent<Animator>();
        mineTimer = Random.Range(1f, 4f);
        
    }
 
    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime + Random.Range(1f, 8f);
        
 
        if (timer >= wanderTimer) {
            timer += Random.Range(2f, 6f);
            if(!running)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);            
                agent.SetDestination(newPos);
                timer = 0;
                walking = true;
                //Invoke("StopWalk", 1f);
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
            mineTimer -= Time.deltaTime;
            if (mineTimer < 0)
            {
                DropMine();
            }
        }
        else
        {
            anim.SetBool("Run", false);
            running = false;
        }


    }

    private void StopWalk()
    {
        walking = false;
    }    

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
        
    }

    public void DropMine()
    {
        Debug.Log("DropMine() start");
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        if (running)
        {
            GameObject Egg = Instantiate(EggPrefab, transform.position + new Vector3(0f, 0.01f, 0f), transform.rotation * Quaternion.Euler(-90f, 0f, 0f));            
        }
        mineTimer = Random.Range(1f, 4f);
    }

    //Allow you to set a custom rotation for a prefab clone eg. the eggmine
    //GameObject pc = (GameObject)Instantiate(Prefab, position, rotation, transform);
    //pc.transform.Rotate(new Vector3(rotationWished.x, rotationWished.y, rotationWished.z));

}
