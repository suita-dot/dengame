using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasGoldKeys = 1;
    public static int hasSilverKeys = 1;
    public static int hasArrows = 3;
    public static int hasLights = 10;
    // Start is called before the first frame update
    void Start()
    {
        //アイテムを読み込む
        hasGoldKeys = PlayerPrefs.GetInt("GoldKeys");
        hasSilverKeys = PlayerPrefs.GetInt("SilverKeys");
        hasArrows = PlayerPrefs.GetInt("Arrows");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムを保存
    public static void SaveItem()
    {
        PlayerPrefs.SetInt("GoldKeys",hasGoldKeys);
        PlayerPrefs.SetInt("SilverKeys",hasSilverKeys);
        PlayerPrefs.SetInt("Arrows",hasArrows);
    }
}
