using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupboardController : MonoBehaviour
{
    public float speed;
    public bool isOpen;
    public Animator animator;

    void openCupboard() // Player should trigger this when opening cupboard
    {
        bool isOpen = true;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.C)) //Code is broken still needs to be fixed Animator needs to be referenced
       {
           animator.SetTrigger("CupboardTrigger");
           openCupboard();
       }        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {            
            animator.SetTrigger("CupboardTrigger");
            openCupboard();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        animator.SetTrigger("CupboardTrigger");
        openCupboard();
    }

}