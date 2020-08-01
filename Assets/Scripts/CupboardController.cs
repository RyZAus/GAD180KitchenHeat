using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupboardController : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
   

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            animator.SetBool("CupboardTriggerBool", isOpen);
        }
               
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("CupboardTrigger");
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator.SetTrigger("CupboardTrigger");
        }            
    }
}