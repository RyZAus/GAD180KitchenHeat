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
            animator.SetBool("CupboardTrigger", isOpen);
        }
               
    }







}