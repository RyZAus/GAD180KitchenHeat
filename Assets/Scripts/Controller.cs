using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public float speed;
    private bool isFacingRight = true;

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 3f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        Debug.Log(Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        //if the input is moving the player to the right but they are facing left...
        if (move > 0 && !isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && isFacingRight)
        {
            // ... flip the player.
            Flip();
        }

        move = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Horizontal", move);

    }
    //function to flip the player sprite
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        //flips the player sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            animator.SetTrigger("Carry");
            //function to pick up item
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position + new Vector3(0f, -1.5f, 0f), Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Ingredient")
                {
                    grabbed = true;

                }


                //function to throw item
            } else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }

            }


        }
        //if an item is grabbed, move it to the holding position
        if (grabbed)
            hit.collider.gameObject.transform.position = holdpoint.position;

        
    }
}
