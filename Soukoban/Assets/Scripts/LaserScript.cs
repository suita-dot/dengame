using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 5f;
    public bool isRight = false;
    public bool isLeft = false;
    public bool isUp = false;
    public bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            rb2d.velocity = new Vector3(speed, 0,0);
        }
        if (isLeft)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (isUp)
        {
            rb2d.velocity = new Vector3(0, speed,0);
        }
        if (isDown)
        {
            rb2d.velocity = new Vector3(0, speed,0);
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
