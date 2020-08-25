using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    public Animator animator;
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 3f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    
    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.D))
		{
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.localScale = new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //function to pick up item
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                //hit = Physics2D.Raycast(transform.position + new Vector3(2f, -1.5f, 0f), Vector2.right * transform.localScale.x, distance);
                //hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Ingredient")
                {
                    grabbed = true;
                    animator.SetTrigger("Carry");            
                }


                //function to throw item
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    //switch character animation to carry position
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                    animator.SetTrigger("Carry");
                }

            }


        }
        //if an item is grabbed, move it to the holding position
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
            

        }


    }
   
}

