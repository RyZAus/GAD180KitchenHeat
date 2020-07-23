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
            if (Input.GetAxis("Horizontal") < 0) //checks to see if the player is going left
            {
                characterController.speed = -8f; //reverses players momentum to remove player from 
                //  Debug.Log("Controller.speed set to -8f");
            }
            

        }
        if (other.tag == "Player")
        {
            if (Input.GetAxis("Horizontal") > 0) //checks to see if the player is going right
            {
                characterController.speed = -8f; //reverses players momentum to remove player from border
               // Debug.Log("Controller.speed set to 8f");

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
