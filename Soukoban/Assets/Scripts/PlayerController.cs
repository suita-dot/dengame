using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Movedistance = 1.0f;
    float Moveduration = 0.2f;
    float Movechecktime = 0.1f;
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    float InputStay = 1.0f;
    public GameManager gameManager;
    Animator animator;
    int direction = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputStay += Time.deltaTime;
        if (InputStay > Moveduration && gameManager.isClear == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                StartCoroutine(Move(Vector3.up));
                InputStay = 0f;
                direction = 2;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Move(Vector3.down));
                InputStay = 0f;
                direction = 0;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Move(Vector3.right));
                InputStay = 0f;
                direction = 3;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Move(Vector3.left));
                InputStay = 0f;
                direction = 1;
            }
        }
        animator.SetInteger("Direction", direction);        
    }

    private IEnumerator Move(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction * Movedistance;
        float elapsedTime = 0f;
        rb2d.velocity = direction*speed;
        while (elapsedTime < Moveduration)
        {
            
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= Movechecktime)
            {
                Vector3 location = transform.position - startPosition;
                if (location.magnitude >= 0.2f)
                {
                    rb2d.velocity = direction*speed;
                }
                else
                {
                    transform.position = startPosition;
                    rb2d.velocity = new Vector3 (0,0,0);
                    yield break;
                }
            }
            yield return null;            
        }
        rb2d.velocity = new Vector3 (0,0,0);
        transform.position = targetPosition;        
    }
}

