using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchChicken : MonoBehaviour
{
    public GameObject caughtChook;
    private float timer = 0;
    public float catchTime = 1;
    public float dropoffTime = 2;

    public bool hasChicken = false;

    private RevealingScript revealingScript;
    
    // Start is called before the first frame update
    void Start()
    {
        caughtChook.SetActive(false);
        hasChicken = false;
        revealingScript = FindObjectOfType<RevealingScript>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Chicken" && hasChicken == false)
        {
            timer = 0;
        }
        else if (collider.gameObject.tag == "DropZone" && hasChicken == true)
        {
            timer = 0;
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Chicken" && hasChicken == false)
        {
            timer += Time.deltaTime;
            if(timer >= catchTime)
            {
                PickupChook(collider.gameObject);
            }

        }
        else if (collider.gameObject.tag == "DropZone" && hasChicken == true)
        {
            timer += Time.deltaTime;
            if (timer >= dropoffTime)
            {
                DropoffChook();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0;
    }

    public void PickupChook(GameObject chook)
    {        
        caughtChook.SetActive(true);
        hasChicken = true;
        Destroy(chook);
    }

    public void DropoffChook()
    {        
        caughtChook.SetActive(false);
        hasChicken = false;
        revealingScript.CatchChook();
    }
    
}
