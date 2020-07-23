using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSmoke : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    float destroyTime = 5;
    // Start is called before the first frame update
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        SmokeGo();
    }

    IEnumerator SmokeGo()
    {
        while (true)
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(this.gameObject);
        }
    }
    
}