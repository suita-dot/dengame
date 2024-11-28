using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileFloor : MonoBehaviour
{
    //BoxCollider2Dを取得その1
    //private ???? stopper;
    //SpriteRendererを取得
    public SpriteRenderer floorRenderer;
    //壊れた床のSpriteを取得
    public Sprite broken;
    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2Dを取得その2
        //stopper = ?????;
    }

    //プレイヤーがすり抜けて出て行った場合に、すり抜けられなくしてかつ画像を壊れた床に変更
    //void ????(???? other)
    //{
        //もし出て行ったgameObjectのタグが”Player”だったら
        //if (????????????)
        //{
            //BoxCollider2DのisTriggerをfalseにしてすり抜けられないようにする
            //?????
            //SpriteRendererのspriteを壊れた床の画像にする。
            //?????
        //}
    //}
}
