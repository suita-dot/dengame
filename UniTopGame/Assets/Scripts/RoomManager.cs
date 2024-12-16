using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();
            if (doorNumber == exit.doorNumber)
            {
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;
                if (exit.direction == ExitDirection.up)
                {
                    y += 1;
                }
                if (exit.direction == ExitDirection.down)
                {
                    y -= 1;
                }
                if (exit.direction == ExitDirection.right)
                {
                    x += 1;
                }
                if (exit.direction == ExitDirection.left)
                {
                    x-= 1;
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x,y);
                break;
            }
        }
        string scenename = PlayerPrefs.GetString("LastScene");
        if (scenename == "BossStage")
        {
            SoundManager.soundManager.PlayBGM(BGMType.InBoss);
        }
        else
        {
            SoundManager.soundManager.PlayBGM(BGMType.InGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void ChangeScene(string scenename, int doornum)
    {
        doorNumber = doornum;
        string nowScene = PlayerPrefs.GetString("LastScene");
        if (nowScene != "")
        {
            SaveDataManager.SaveArrangeData(nowScene);
        }
        PlayerPrefs.SetString("LastScene",scenename);
        PlayerPrefs.SetInt("LastDoor", doornum);
        ItemKeeper.SaveItem();

        SceneManager.LoadScene(scenename);
    }
}
