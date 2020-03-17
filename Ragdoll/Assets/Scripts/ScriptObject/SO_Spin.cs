using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO_Spin", menuName = "ScriptObject/SO_Spin", order = 1)]
public class SO_Spin : ScriptableObject
{
    public List<DataSpin> SpinDatas;
    //public DataSave<BaseStat> dataList;
    public void LoadDataSpin(List<Dictionary<string, string>> dataCSV)
    {
        SpinDatas = new List<DataSpin>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            DataSpin _data = new DataSpin(dataCSV[i]);
            SpinDatas.Add(_data);
        }
    }
}
[System.Serializable]
public class DataSpin
{
    public int id;
    public string json;

    public DataSpin(Dictionary<string, string> data)
    {
        int.TryParse(data["ID"], out id);
        json = CSVReader.ParseString(data["JSON"]);
    }
}
