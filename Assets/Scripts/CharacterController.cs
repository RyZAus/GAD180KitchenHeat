using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        //getting the input from the horizontal axis. times by speed. Storing in 'translation' float.
        float translationHorizontal = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Horizontal", translationHorizontal);
        //translating the transform on this object, times vector forward, times deltatime, times the translation which is the input
        transform.Translate(Vector3.right * Time.deltaTime * translationHorizontal);
        if (translationHorizontal > 0.0)
        {
            playerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (translationHorizontal < 0.0)
        {
            playerTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
