using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Boundaries : MonoBehaviour
{
    public CharacterController characterController;
    

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // if (characterController = other.GetComponent<CharacterController>())
        
        
        if (other.tag == "Player")
        {
            if (Input.GetAxis("Horizontal") < 0.1)
            {
                characterController.speed = 0;
            }
                       
            else
            {
                characterController.speed = 8;
            }
          
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        characterController.speed = 8;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
