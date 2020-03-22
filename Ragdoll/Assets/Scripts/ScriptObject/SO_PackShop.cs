using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_PackShop", menuName = "ScriptObject/SO_PackShop", order = 1)]
public class SO_PackShop : ScriptableObject
{
    public List<DataPack> PackDatas;
    //public DataSave<BaseStat> dataList;
    public void LoadDataPack(List<Dictionary<string, string>> dataCSV)
    {
        PackDatas = new List<DataPack>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            DataPack _data = new DataPack(dataCSV[i]);
            PackDatas.Add(_data);
        }
    }
}
[System.Serializable]
public class DataPack
{
    public int ID;
    public string IAP;
    public string PACK;
    public string CODE;
    public DataPack(Dictionary<string, string> data)
    {
        int.TryParse(data["ID"], out ID);
        IAP = data["IAP"];
        PACK = CSVReader.ParseString(data["PACK"]);
        CODE = data["CODE"];
    }
}
