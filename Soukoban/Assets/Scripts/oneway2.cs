using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneway2 : MonoBehaviour
{
    public onewayentry entry;
    public onewayexit exit;
    private BoxCollider2D barrier;
    // Start is called before the first frame update
    void Start()
    {
        barrier = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entry.playerHere == true)
        {
            barrier.isTrigger = true;
        }
        if (exit.playerHere == true)
        {
            barrier.isTrigger = false;
        }
    }
    
}
