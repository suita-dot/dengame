using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileFloor : MonoBehaviour
{
    private BoxCollider2D stopper;
    public SpriteRenderer floorRenderer;
    public Sprite broken;
    // Start is called before the first frame update
    void Start()
    {
        stopper = GetComponent<BoxCollider2D>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            stopper.isTrigger = false;
            floorRenderer.sprite = broken;
        }
    }
}
