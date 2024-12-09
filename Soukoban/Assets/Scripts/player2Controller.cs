using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    float Movedistance = 1.0f;
    float Moveduration = 0.2f;
    float Movechecktime = 0.1f;
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    float InputStay = 1.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputStay += Time.deltaTime;
        if (InputStay > Moveduration)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.velocity = Vector3.up *speed;
                InputStay = 0f;
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Move(Vector3.down));
                InputStay = 0f;
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Move(Vector3.right));
                InputStay = 0f;
                
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Move(Vector3.left));
                InputStay = 0f;
                
            }
        }
    }

    private IEnumerator Move(Vector3 playerdirection)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + playerdirection * Movedistance;
        float elapsedTime = 0f;
        rb2d.velocity = playerdirection*speed;
        while (elapsedTime < Moveduration)
        {
            
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= Movechecktime)
            {
                Vector3 location = transform.position - startPosition;
                if (location.magnitude >= 0.2f)
                {
                    rb2d.velocity = playerdirection*speed;
                }
                else
                {
                    transform.position = new Vector3(Mathf.Round(startPosition.x),Mathf.Round(startPosition.y),transform.position.z);
                    rb2d.velocity = new Vector3 (0,0,0);
                    yield break;
                }
            }
            yield return null;            
        }
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),transform.position.z);        
    }
}
