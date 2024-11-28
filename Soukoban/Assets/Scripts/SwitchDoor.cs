using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public BoxCollider2D door;
    private SpriteRenderer doorSprite;
    public Switch switchButton;
    public bool isBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlocked == false && switchButton.isPushed == false)
        {
            door.isTrigger = false;
            doorSprite.enabled = true;
        }
        if (switchButton.isPushed == true)
        {
            door.isTrigger = true;
            doorSprite.enabled = false;            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
        isBlocked = true;        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isBlocked = false;
        if (switchButton.isPushed == false)
        {
            doorSprite.enabled = true;
            door.isTrigger = true;
        } 
    }
}
