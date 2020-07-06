using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    // Speed variable for making our character speed correct in unity
    public float speed;
    // Make a animator
    public Animator animator;
    // Using a transformer for the the player to flip it
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        float translationHorizontal = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Horizontal", translationHorizontal);
        //A way to Translate the character transform to flip the character, aka our object. Times the verctor forward. Times deltatime. Times the translation which is the input.
        transform.Translate(Vector3.right * Time.deltaTime * translationHorizontal);
        if (translationHorizontal > 0.0)
        {
            playerTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            playerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
