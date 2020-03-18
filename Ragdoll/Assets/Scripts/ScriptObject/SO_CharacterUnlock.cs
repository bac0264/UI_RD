using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_CharacterUnlock", menuName = "ScriptObject/SO_CharacterUnlock", order = 1)]
public class SO_CharacterUnlock : ScriptableObject
{
    public List<DataCharacterUnlock> characterDatas;
    //public DataSave<BaseStat> dataList;
    public void LoadUpgradeCharacter(List<Dictionary<string, string>> dataCSV)
    {
        characterDatas = new List<DataCharacterUnlock>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            DataCharacterUnlock _data = new DataCharacterUnlock(dataCSV[i]);
            characterDatas.Add(_data);
        }
    }
}
[System.Serializable]
public class DataCharacterUnlock
{
   // public int ID;
    public int ATK;
    public int HP;
    public int VIDEO_UNLOCK;
    public int GOLD_UNLOCK;
    public int LEVEL_UNLOCK;
    public int IS_GIFT;

    public DataCharacterUnlock(Dictionary<string, string> data)
    {
      //  int.TryParse(data["ID"], out ID);
        int.TryParse(data["ATK"], out ATK);
        int.TryParse(data["HP"], out HP);
        int.TryParse(data["VIDEO_UNLOCK"], out VIDEO_UNLOCK);
        int.TryParse(data["GOLD_UNLOCK"], out GOLD_UNLOCK);
        int.TryParse(data["LEVEL_UNLOCK"], out LEVEL_UNLOCK);
        int.TryParse(data["IS_GIFT"], out IS_GIFT);
    }
}
