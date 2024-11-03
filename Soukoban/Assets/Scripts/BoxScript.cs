using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    float Mindistance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 Distance = transform.position - player.transform.position;
        Vector3 normalizedDistance = Distance.normalized;
        if (Distance.magnitude < Mindistance)
        {
            rb2d.velocity = normalizedDistance*speed;
        }
    }

    
}
