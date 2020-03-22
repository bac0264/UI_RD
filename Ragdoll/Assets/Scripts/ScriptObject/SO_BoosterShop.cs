using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_BoosterShop", menuName = "ScriptObject/SO_BoosterShop", order = 1)]
public class SO_BoosterShop : ScriptableObject
{
    public List<BoosterShopStat> boosterList;
    //public DataSave<BaseStat> dataList;
    public void LoadBoosters(List<Dictionary<string, string>> dataCSV)
    {
        boosterList = new List<BoosterShopStat>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            BoosterShopStat _data = new BoosterShopStat(dataCSV[i]);
            boosterList.Add(_data);
        }
    }
}

[System.Serializable]
public class BoosterShopStat : BoosterStat
{
    public string IAP;
    public string CODE;
    public BoosterShopStat(long value, TypeOfBooster typeOfBooster) : base(value, typeOfBooster)
    {

    }
    public BoosterShopStat(Dictionary<string, string> data) : base(data)
    {
        IAP = data["IAP"];
        CODE = data["CODE"];
        NAME = Type.BoosterStat.ToString();
        this.TYPE = (int)Type.BoosterStat;
    }
}

