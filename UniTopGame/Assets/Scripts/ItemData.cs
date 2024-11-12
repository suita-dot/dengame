using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    arrow,
    goldkey,
    silverkey,
    life,
    light,
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeId = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == ItemType.goldkey)
            {
                ItemKeeper.hasGoldKeys += count;
            }
            else if (type == ItemType.silverkey)
            {
                ItemKeeper.hasSilverKeys += count;
            }
            else if (type == ItemType.arrow)
            {
                ItemKeeper.hasArrows += count;
                ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
            }
            else if (type == ItemType.life)
            {
                if (PlayerScript.hp <3)
                {
                    PlayerScript.hp++;
                }
            }
            else if (type == ItemType.light)
            {
                ItemKeeper.hasLights += count;
                GameObject.FindObjectOfType<PlayerLightController>().LightUpdate();
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            itemBody.gravityScale = 2.5f;
            itemBody.AddForce(new Vector2(0,6),ForceMode2D.Impulse);
            Destroy(gameObject,0.5f);
        }
    }
}
