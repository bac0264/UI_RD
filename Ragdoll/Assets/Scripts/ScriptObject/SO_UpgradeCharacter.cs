using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_UpgradeCharacter", menuName = "ScriptObject/SO_UpgradeCharacter", order = 1)]
public class SO_UpgradeCharacter : ScriptableObject
{
    public List<DataUpgradeCharacter> upgradeCharacterDatas;
    //public DataSave<BaseStat> dataList;
    public void LoadUpgradeCharacter(List<Dictionary<string, string>> dataCSV)
    {
        upgradeCharacterDatas = new List<DataUpgradeCharacter>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            DataUpgradeCharacter _data = new DataUpgradeCharacter(dataCSV[i]);
            upgradeCharacterDatas.Add(_data);
        }
    }
}
[System.Serializable]
public class DataUpgradeCharacter
{
    public int LEVEL;
    public int ATK;
    public int HP;
    public long GOLD;

    public DataUpgradeCharacter(Dictionary<string, string> data)
    {
        int.TryParse(data["LEVEL"], out LEVEL);
        int.TryParse(data["ATK"], out ATK);
        int.TryParse(data["HP"], out HP);
        long.TryParse(data["GOLD"], out GOLD);
    }
}
