using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           transform.Translate(new Vector3(0,1,0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           transform.position -= new Vector3(0,1,0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           transform.position += new Vector3(1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           transform.position -= new Vector3(1,0,0);
        }
    }
}
