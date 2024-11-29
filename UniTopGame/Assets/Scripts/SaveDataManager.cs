using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataList arrangeDataList;//配置データ
    // Start is called before the first frame update
    void Start()
    {
        //SaveDataList初期化
        //arrangeDataList変数を初期化
        arrangeDataList = new SaveDataList();
        //arrangeDataListの中のsavaDataList配列を空の状態で作る
        arrangeDataList.saveDatas = new SaveData[]{};
        //シーン名を読み込む
        string stageName = PlayerPrefs.GetString("LastScene");
        //シーン名をキーにして保存データを読み込む
        string data = PlayerPrefs.GetString(stageName);
        //ここで空文字が帰ってきたら何もしない
        if (data != "")//セーブデータが存在する場合
        {
            //JSONデータからSavaDataListクラスに変換
            //オブジェクト = JsonUtility.FromJson<型(クラス名)>(JSONテキスト);
            arrangeDataList = JsonUtility.FromJson<SaveDataList>(data);
            //arrangeDataListのsaveDatasはSaveDataの配列になっている
            //入ってる数だけループを回す
            for (int i=0; i<arrangeDataList.saveDatas.Length; i++)
            {
                //i番目のSaveDataを配列から取り出す
                SaveData savedata = arrangeDataList.saveDatas[i];
                //タグのゲームオブジェクトを探す
                string objTag = savedata.objTag;
                //???
                GameObject[] objects = GameObject.FindGameObjectsWithTag(objTag);
                for (int ii = 0; ii< objects.Length; ii++)
                {
                    //配列からGameObjectを取り出す
                    GameObject obj = objects[ii];
                    //取り出したgameObjectのタグを調べる
                    //それぞれarrangeIdが同じなら...
                    if (objTag == "Door")
                    {
                        Door door = obj.GetComponent<Door>();
                        if (door.arrangeId == savedata.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }
                    else if (objTag == "ItemBox")
                    {
                        ItemBox box = obj.GetComponent<ItemBox>();
                        if (box.arrangeId == savedata.arrangeId)
                        {
                            box.isClosed = false;//宝箱を開く
                            box.GetComponent<SpriteRenderer>().sprite = box.openImage;
                        }
                    }
                    else if (objTag == "Item")
                    {
                        ItemData item = obj.GetComponent<ItemData>();
                        if (item.arrangeId == savedata.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }
                    else if (objTag == "Enemy")
                    {
                        EnemyController enemy = obj.GetComponent<EnemyController>();
                        if (enemy.arrangeId == savedata.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }
                }  
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //「開いたドア」
    //「開いた宝箱」
    //「取ったアイテム」
    //「倒した敵」
    //この4つのarrnageId(配置物を識別するための数値)とタグをSaveDataListに記録
    public static void SetArrangeId(int arrangeId, string objTag)
    {
        if (arrangeId == 0||objTag == "")
        {
            //arrangeIdが0か、objTagが空文字なら
            //記録せずにメソッドを抜ける
            return;
        }
        //arrangeDataList.savaDatasはSaveDataの配列
        //追加するためにarrangeDataList.saveDatasより1つ多いSaveData配列を作る
        SaveData[] newSavedatas = new SaveData[arrangeDataList.saveDatas.Length +1];
        //データをコピーする
        for (int i = 0; i< arrangeDataList.saveDatas.Length; i++)
        {
            //SaveData配列i番目にSaveDataの配列のi番目を入れる
            newSavedatas[i] = arrangeDataList.saveDatas[i];
        }
        //SaveData作成
        SaveData savedata = new SaveData();
        savedata.arrangeId = arrangeId;//Id記録
        savedata.objTag = objTag;//タグを記録
        //新しいSaveDataを配列の最後に追加
        newSavedatas[arrangeDataList.saveDatas.Length] = savedata;
        //SaveDataの配列を更新
        arrangeDataList.saveDatas = newSavedatas;
    }

    //配置データの保存
    //シーン名をキーにしてJSONデータを保存する
    public static void SaveArrangeData(string stageName)
    {
        //SaveDataの配列がnullでなければデータがあると判断
        if (arrangeDataList.saveDatas != null && stageName != "")
        {
            //arrangeDataListをJSONテキストに変換
            //JSONテキスト = JsonUtility.ToJson(オブジェクト);
            string saveJson = JsonUtility.ToJson(arrangeDataList);
            //シーン名をキーにしてJSONテキストを保存
            PlayerPrefs.SetString(stageName,saveJson);
        }
    }
    //後はこのクラスのSetArrangeDataメソッドとSaveArrangeDataメソッドを良い感じの場所で使う
}
