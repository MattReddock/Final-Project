using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatchChicken : MonoBehaviour
{
    public GameObject caughtChook;
    private float timer = 0;
    public float catchTime = 2f;
    public float dropoffTime = 2f;
    public Transform ChickenCount;
    private int chickensCaught = 0;
    public GameObject[] chickensInLevel;
    public GameObject[] allCaught;
    
    private int chickens;
    //private int level;

    public bool hasChicken = false;

    private RevealingScript revealingScript;
    
    // Start is called before the first frame update
    void Start()
    {
        chickensInLevel = GameObject.FindGameObjectsWithTag("Chicken");
        allCaught = GameObject.FindGameObjectsWithTag("Chicken");
        ChickenCount.GetComponent<Text>().text = ("Collected Chickens: " + chickensCaught + "/" + chickensInLevel.Length);
        caughtChook.SetActive(false);
        hasChicken = false;
        revealingScript = FindObjectOfType<RevealingScript>();
        chickens = chickensInLevel.Length;
        //level = SceneManager.GetActiveScene();
    }

    public void Update()
    {
        
        
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        caughtChook.SetActive(true);
        hasChicken = true;
        chook.SetActive(false);
    }

    public void DropoffChook()
    {
        caughtChook.SetActive(false);
        hasChicken = false;
        revealingScript.CatchChook();
        chickens--;
        allCaught = GameObject.FindGameObjectsWithTag("Chicken");
    }
    
}
