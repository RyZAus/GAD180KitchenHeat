using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//declare our document
public class CharacterController : MonoBehaviour
{
    //initial variables
    public float speed = 8;
    public Animator animator;
    public Transform playerTransform;
    //Test Code
    public GameObject Character;
    //Test Code
    public float translationHorizontal;


    


    void Update()
    {
        
        //Call the bounds setter
      
        //getting the input from the horizontal axis. times by speed. Storing in 'translation' float
        translationHorizontal = Input.GetAxis("Horizontal") * speed;
        
        
        //set our animator    
        animator.SetFloat("Horizontal", translationHorizontal);
       
       
        //translating the transform on this object, times vector forward, times deltatime, times the translation which is the input   
        transform.Translate(Vector3.right * Time.deltaTime * translationHorizontal);
       

       
        //flips our character to whatever direction it is walking in
        if (translationHorizontal > 0.0)
        {
            playerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (translationHorizontal < 0.0)
        {
            playerTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        //Actions of player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Carry");
            //if (in trigger)
            {
                //Transform the first object to be the child of the second
                //object1.transform.parent = Character.transform
            }
        }
    }
}
