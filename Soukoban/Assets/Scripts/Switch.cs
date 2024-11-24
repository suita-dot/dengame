using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isPushed = false;
    public bool remove = false;
    public float OpenTime;
    public SpriteRenderer SwitchRenderer;
    public Sprite SwitchOn;
    public Sprite SwitchOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        isPushed = true;
        SwitchRenderer.sprite = SwitchOn;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(SwitchPushed(OpenTime));
    }
    private IEnumerator SwitchPushed(float time)
    {
        float count = 0f;
        float removetime = time - 2f;
        while (count <= time)
        {
            count += Time.deltaTime;
            isPushed = true;
            if (count >= removetime)
            {
                remove = true;
            }
            yield return null;
        }
        isPushed = false;
        remove = false;
        SwitchRenderer.sprite = SwitchOff;
    }

}
