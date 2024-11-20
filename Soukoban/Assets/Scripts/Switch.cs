using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isPushed = false;
    public float OpenTime;
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
    }
    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(SwitchPushed(OpenTime));
    }
    private IEnumerator SwitchPushed(float time)
    {
        float count = 0f;
        
        while (count <= time)
        {
            count += Time.deltaTime;
            isPushed = true;
            yield return null;
        }
        isPushed = false;
    }

}
