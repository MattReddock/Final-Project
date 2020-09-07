using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealingScript : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    
    public void Start()
    {
        
        hiddenObjects = GameObject.FindGameObjectsWithTag("HiddenObj");

        foreach (GameObject child in hiddenObjects)
        {

            if (child != this.gameObject)
            {
                child.SetActive(false);
            }
        }
        
    }    

    public void CatchChook()
    {
        foreach (GameObject child in hiddenObjects)
        {
            if (child.activeSelf == false)
            {
                child.SetActive(true);
                break;
            }
        }
        
    }
}
