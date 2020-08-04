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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log ("Trigger Enter");
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter");
            animator.SetTrigger("CupboardTrigger");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger Exit");
        if (collider.tag == "Player")
        {            
            Debug.Log("Player Exit");
            animator.SetTrigger("CupboardTrigger");
        }            
    }
}