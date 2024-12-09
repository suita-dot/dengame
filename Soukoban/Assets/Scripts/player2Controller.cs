using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    
    Vector3 koshiten;
    Vector3 gap;
    Vector3 goal;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        koshiten = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),transform.position.z);
        gap = transform.position - koshiten;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.velocity = Vector3.up *speed;            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.velocity = Vector3.down *speed;            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector3.right *speed;            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector3.left *speed;            
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            StartCoroutine(Up());
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StartCoroutine(Down());
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(Right());
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(Left());
        }
        
    }
    private IEnumerator Up()
    {
        Vector3 targetPosition = new Vector3 (transform.position.x, Mathf.Ceil(transform.position.y), transform.position.z);
        float gap = Mathf.Ceil(transform.position.y)-transform.position.y;
        float estimateTime = gap/speed;
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Down()
    {
        Vector3 targetPosition = new Vector3 (transform.position.x, Mathf.Floor(transform.position.y), transform.position.z);
        float gap = -Mathf.Floor(transform.position.y)+transform.position.y;
        float estimateTime = gap/speed;
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Right()
    {
        Vector3 targetPosition = new Vector3 (Mathf.Ceil(transform.position.x), transform.position.y, transform.position.z);
        float gap = Mathf.Ceil(transform.position.x)-transform.position.x;
        float estimateTime = gap/speed;
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Left()
    {
        Vector3 targetPosition = new Vector3 (Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);
        float gap = -Mathf.Floor(transform.position.x)+transform.position.x;
        float estimateTime = gap/speed;
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
}