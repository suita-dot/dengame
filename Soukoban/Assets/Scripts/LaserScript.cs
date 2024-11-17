using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 15f;
    public LaserGunScript laserGunScript;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laserGunScript != null)
        {
            if (laserGunScript.isRight == true)
            {
                rb2d.velocity = new Vector2(speed, 0);
            }
            else if (laserGunScript.isLeft)
            {
                rb2d.velocity= new Vector2(-speed,0);
            }
            else if (laserGunScript.isUp)
            {
                rb2d.velocity = new Vector2(0, speed);
            }
            else if (laserGunScript.isDown)
            {
                rb2d.velocity = new Vector2(0, -speed);
            }  
        }
              
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Lasergun"&& other.gameObject.tag != "Goal")
        {
            Destroy(gameObject);
        }
        
    }
}
