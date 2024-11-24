using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public BoxCollider2D door;
    private SpriteRenderer doorSprite;
    public Switch switchButton;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchButton.isPushed == false)
        {
            door.enabled = true;
            door.isTrigger = false;
            doorSprite.enabled = true;
        }
        else if (switchButton.isPushed == true)
        {
            door.isTrigger = true;
            door.enabled = false;
            doorSprite.enabled = false;            
        }
        if (switchButton.remove == true)
        {            
            door.enabled = true;
        }
    }
}
