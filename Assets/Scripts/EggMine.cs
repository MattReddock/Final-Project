using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMine : MonoBehaviour
{
    float lifetime = 5.0f;
    private Movement playerMovement;

    


    private void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
        
    }

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerMovement.HitEgg();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerMovement.LeaveEgg();
        }
    }

    void SafetyLine()
    {
        playerMovement.LeaveEgg();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SafetyLine", 5f);
        Destroy(gameObject, lifetime);
    }

    
}
