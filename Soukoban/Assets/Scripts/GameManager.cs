using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int remaingoals = 1;
    public bool isClear = false;
    public Text clearText;
    public GameObject nextStage;

    // Start is called before the first frame update
    void Start()
    {
        clearText.text = "";
        nextStage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(remaingoals);
        if (remaingoals <= 0)
        {
            isClear = true;            
            clearText.text = "CLEAR";
            nextStage.SetActive(true);
        }
    }
}
