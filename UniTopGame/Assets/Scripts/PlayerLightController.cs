using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    Light2D light2d;
    PlayerScript playerCnt;
    float lightTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        light2d = GetComponent<Light2D>();
        light2d.pointLightOuterRadius = (float)ItemKeeper.hasLights;
        playerCnt = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0,0,playerCnt.angleZ-90);
        if (ItemKeeper.hasLights>0)
        {
            lightTimer += Time.deltaTime;
            if (lightTimer>10.0f)
            {
                lightTimer=0.0f;
                ItemKeeper.hasLights--;
                light2d.pointLightOuterRadius = ItemKeeper.hasLights;
            }
        }
    }
    public void LightUpdate()
    {
        light2d.pointLightOuterRadius = ItemKeeper.hasLights;
    }
}
