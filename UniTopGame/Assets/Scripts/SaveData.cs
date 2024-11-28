using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//このクラスは保存する対象です
public class SaveData 
{
    public int arrangeId = 0;
    public string objTag = "";
}

[System.Serializable]
public class SaveDataList
{
    public SaveData[] saveDatas;//SaveDataの配列
}

