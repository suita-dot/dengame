using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D xxxx)
    {
        if (xxxx.gameObject.tag == "Box")
        {
            gameManager.remaingoals -= 1;
        }
    }
    void OnTriggerExit2D(Collider2D xxxx)
    {
        if (xxxx.gameObject.tag == "Box")
        {
            gameManager.remaingoals += 1;
        }
    }
}
