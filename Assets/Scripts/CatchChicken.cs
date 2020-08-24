using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchChicken : MonoBehaviour
{
    public GameObject Chooks = null;
    private float Time = 0;
    public float captureTime = 3;
    public float dropoffTime = 3;

    private bool m_hasPassenger = false;

    private void Start()
    {
        Chooks.SetActive(false);
        m_hasPassenger = false;

    }

    void OnTriggerEnter(Collider collider) 
    { 
        if (collider.gameObject.tag == "Swimmer" && m_hasPassenger == false)
        { 
            Time = 0;            
        } 
        else if (collider.gameObject.tag == "DropZone" && m_hasPassenger == true)
        {
            Time = 0; 
        }
        
    }

    void OnTriggerStay(Collider collider) 
    { 
        if (collider.gameObject.tag == "Swimmer" && m_hasPassenger == false) 
        {
            Time += UnityEngine.Time.deltaTime; Debug.Log((captureTime / Time));

            if (Time >= captureTime) 
            { 
                PickupSwimmer(collider.gameObject); 
            } 
        } 
        else if (collider.gameObject.tag == "DropZone" && m_hasPassenger == true) 
        {
            Time += UnityEngine.Time.deltaTime; 
            if (Time >= dropoffTime) 
            { 
                DropoffSwimmer(); 
            }

        }
        
    }

    private void OnTriggerExit(Collider other) 
    { 
        Time = 0; 
    }

    public void PickupSwimmer(GameObject swimmer)
    {
        swimmer.SetActive(false);
        Chooks.SetActive(true);
        m_hasPassenger = true;
    }
    public void DropoffSwimmer()
    {
        Chooks.SetActive(false);
        m_hasPassenger = false;
    }
}
