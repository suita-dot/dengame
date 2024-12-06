using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onewayexit : MonoBehaviour
{
    public bool playerHere = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;
        }
    }
}
