using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    private BoxCollider2D door;
    public Switch switchButton;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchButton.isPushed == false)
        {
            door.isTrigger = false;
        }
        else if (switchButton.isPushed == true)
        {
            door.isTrigger = true;
        }
    }
}
