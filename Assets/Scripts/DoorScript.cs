using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("playerNearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("playerNearby", false);
    }
}
