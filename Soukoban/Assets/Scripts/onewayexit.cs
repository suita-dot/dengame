using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onewayexit : MonoBehaviour
{
    public bool playerHere = false;
    public bool boxHere = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = true;
        }
        if (other.gameObject.tag == "Box"||other.gameObject.tag == "Dummy")
        {
            boxHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;
        }
        if (other.gameObject.tag == "Box"||other.gameObject.tag == "Dummy")
        {
            boxHere = false;
        }
    }
}
