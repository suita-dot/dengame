using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    //PlayerControllerを取得
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //もしぶつかったゲームオブジェクトのタグが"Player"で
        //かつhasKeysの値が1以上なら
        if (collision.gameObject.tag == "Player" && player.hasKeys>=1)
        {
            //ドアを解錠＝ドアのゲームオブジェクトを破壊
            Destroy(gameObject);
            //PlayerControllerのhasKeysを1減らす
            player.hasKeys -= 1;
        }
    }
}
