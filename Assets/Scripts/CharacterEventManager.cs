using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEventManager : MonoBehaviour
{
    // Our unity events
    public UnityEvent Standing = new UnityEvent();
    public UnityEvent Running = new UnityEvent();
    public UnityEvent run = new UnityEvent();
    public UnityEvent walk = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Standing != null || Running != null)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                Running.Invoke();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Running.Invoke();
                }
                else
                {
                    Standing.Invoke();
                }
            }
        }
        else
        {
            //give ourselves a little hint if this has happened
            Debug.Log("Fix your code (Running Standing)");
        }
    }
}