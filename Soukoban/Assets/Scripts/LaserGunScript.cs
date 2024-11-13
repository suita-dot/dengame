using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    public bool isRight = false;
    public bool isLeft = false;
    public bool isUp = false;
    public bool isDown = false;
    private float interval = 3.0f;
    private float elapsedTime = 1.0f;
    private int direction = 1;
    public GameObject laser;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > interval)
        {
            elapsedTime = 0f;
            Instantiate (laser, transform.position, Quaternion.identity);
        }
        if (isRight)
        {
            direction = 1;
        }
        if (isLeft)
        {
            direction = 2;
        }
    }

    
}
