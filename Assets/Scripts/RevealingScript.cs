using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealingScript : MonoBehaviour
{
    public Transform[] hiddenObjects;
    
    public void Start()
    {
        
        hiddenObjects = GetComponentsInChildren<Transform>();

        foreach (Transform child in hiddenObjects)
        {
            if (child.gameObject != this.gameObject)
            {
                child.gameObject.SetActive(false);
            }
        }
        
    }    

    public void CatchChook()
    {
        foreach (Transform child in hiddenObjects)
        {
            if (child.gameObject.activeSelf == false)
            {
                child.gameObject.SetActive(true);
                break;
            }
        }
        
    }
}
