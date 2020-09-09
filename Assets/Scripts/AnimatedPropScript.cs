using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPropScript : MonoBehaviour
{
    private Animator anim;
    public bool eating;
    public bool running;
    public bool walking;    
    public bool turnHead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(eating)
        {
            anim.SetBool("Eat", true);
        }
        else
        {
            anim.SetBool("Eat", false);
        }

        if(running)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if(walking)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(turnHead)
        {
            anim.SetBool("Turn Head", true);
        }
        else
        {
            anim.SetBool("Turn Head", false);
        }
        
    }
}
