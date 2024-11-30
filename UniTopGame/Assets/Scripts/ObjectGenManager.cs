using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenManager : MonoBehaviour
{
    ObjectGenPoint[] objGens;
    // Start is called before the first frame update
    void Start()
    {
        objGens = GameObject.FindObjectsOfType<ObjectGenPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
