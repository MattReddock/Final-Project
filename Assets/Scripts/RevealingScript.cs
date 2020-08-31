using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealingScript : MonoBehaviour
{
    public Transform[] hiddenObjects;
    

    public void Start()
    {
        
        //if ()
        //{
            hiddenObjects = GetComponentsInChildren<Transform>();
            foreach (Transform child in hiddenObjects)
            {
                child.gameObject.SetActive(false);
            }
        //}
    }

    public void CatchChook()
    {
        foreach(Transform child in hiddenObjects)
        {
            if(child.gameObject.activeSelf == false)
            {
                child.gameObject.SetActive(true);
                return;
            }
        }
    }
}
