using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatchChicken : MonoBehaviour
{
    public GameObject heldChook;
    private float timer = 0;
    public float catchTime = 2f;
    public float dropoffTime = 2f;
    public Transform ChickenCount;
    private int chickensCaught = 0;
    public GameObject[] chickensInLevel;
    public GameObject[] allCaught;
    private Movement movement;
    private float holdTimer = 0f;
    private float looseTimer = 6f;
    
    private int chickens;
    public Transform thePlayer;
    public GameObject capturedChook;

    public bool hasChicken = false;

    private RevealingScript revealingScript;
    
    
    void Start()
    {
        chickensInLevel = GameObject.FindGameObjectsWithTag("Chicken");
        allCaught = GameObject.FindGameObjectsWithTag("Chicken");
        ChickenCount.GetComponent<Text>().text = ("Collected Chickens: " + chickensCaught + "/" + chickensInLevel.Length);
        heldChook.SetActive(false);
        hasChicken = false;
        revealingScript = FindObjectOfType<RevealingScript>();
        chickens = chickensInLevel.Length;
        movement = FindObjectOfType<Movement>();
        
    }

    public void Update()
    {
        
        if(hasChicken == true)
        {
            holdTimer += Time.deltaTime;
            if(holdTimer >= looseTimer)
            {
                LooseChook();
            }
        }
        

        if(chickens == 0)
        {
            foreach(GameObject chookers in chickensInLevel)
                GameObject.Destroy(chookers);
        }
        if(allCaught.Length == 0)
        {
            Levels();
        }
        
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

    public void Levels()
    {
        int Counter;

        Counter = SceneManager.GetActiveScene().buildIndex;
        if (Counter != 3)
        {
            SceneManager.LoadScene(Counter + 1);
        }

        if(Counter >= 3)
        {
            movement.Winner();
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
                chickensCaught++;
                ChickenCount.GetComponent<Text>().text = ("Collected Chickens: " + chickensCaught + "/" + chickensInLevel.Length);
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
        hasChicken = true;
        capturedChook = chook;
        heldChook.SetActive(true);
        capturedChook.SetActive(false);
        
    }

    public void DropoffChook()
    {
        hasChicken = false;
        heldChook.SetActive(false);        
        revealingScript.CatchChook();
        chickens--;
        allCaught = GameObject.FindGameObjectsWithTag("Chicken");
        //capturedChook.SetActive(false);
    }

    public void LooseChook()
    {
        hasChicken = false;
        holdTimer = 0f;
        capturedChook.SetActive(true);
        capturedChook.transform.position = thePlayer.transform.position + transform.forward * 2f;        
        heldChook.SetActive(false);
        
        
    }
    
}
