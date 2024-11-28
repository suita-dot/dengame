using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //PlayerControllerを取得
    public PlayerController player;
    

    void OnTriggerEnter2D (Collider2D other)
    {
        //もしぶつかったゲームオブジェクトのタグが”Player”なら
        if (other.gameObject.tag == "Player")
        {
            //鍵のゲームオブジェクトを破壊
            Destroy(gameObject);
            //PlayerControllerの整数値hasKeysを1追加
            player.hasKeys ++;
        }
    }
}
