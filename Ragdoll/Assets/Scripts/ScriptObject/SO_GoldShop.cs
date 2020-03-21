using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_GoldShop", menuName = "ScriptObject/SO_GoldShop", order = 1)]
public class SO_GoldShop : ScriptableObject
{
    public List<ResourceStat> goldLists;
    //public DataSave<BaseStat> dataList;
    public void LoadUpgradeCharacter(List<Dictionary<string, string>> dataCSV)
    {
        goldLists = new List<ResourceStat>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            ResourceStat _data = new ResourceStat(dataCSV[i]);
            goldLists.Add(_data);
        }
    }
}

