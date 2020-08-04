using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public float speed;
    private bool isFacingRight = true;   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
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

    
 }
    

