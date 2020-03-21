using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_GoldShop", menuName = "ScriptObject/SO_GoldShop", order = 1)]
public class SO_GoldShop : ScriptableObject
{
    public List<ResourceShopStat> goldLists;
    //public DataSave<BaseStat> dataList;
    public void LoadResources(List<Dictionary<string, string>> dataCSV)
    {
        goldLists = new List<ResourceShopStat>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            ResourceShopStat _data = new ResourceShopStat(dataCSV[i]);
            goldLists.Add(_data);
        }
    }
}

[System.Serializable]
public class ResourceShopStat : ResourceStat
{
    public string IAP;
    public string CODE;
    public ResourceShopStat(long value, TypeOfResource typeOfResource) : base(value, typeOfResource)
    {

    }
    public ResourceShopStat(Dictionary<string, string> data) : base(data)
    {
        IAP = data["IAP"];
        CODE = data["CODE"];
    }
}

