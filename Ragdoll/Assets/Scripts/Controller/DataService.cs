using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class DataService : IDataService
{
    //DataSave<BaseStat> BaseStat_dataSave;
    DataSave<ItemStat> ItemStat_DataSave;
    DataSave<ResourceStat> ResourceStat_DataSave;
    public DataService()
    {
        if (PlayerPrefs.GetInt("First", 0) == 0)
        {
            //basestat_datasave = new datasave<basestat>();
            //basestat_datasave.results.add(new resourcestat(1, resourcestat.typeofresource.gem));
            //basestat_datasave.results.add(new resourcestat(2, resourcestat.typeofresource.gold));
            //for (int i = 0; i < 20; i++)
            //{
            //    if (i % 3 == 0)
            //        basestat_datasave.results.add(new itemstat(1, itemstat.typeofitem.armor, 0));
            //    else if (i % 3 == 2) basestat_datasave.results.add(new basestat(2));
            //}
            Save();
            PlayerPrefs.SetInt("First", 1);
        }
        else
            Load();
    }
    public DataSave<T> GetDataSaveWithType<T>()
    {
        if (typeof(T).ToString().Equals("ItemStat")) return (DataSave<T>)(object) ItemStat_DataSave;
        else if(typeof(T).ToString().Equals("ResourceStat")) return (DataSave<T>)(object)ResourceStat_DataSave;
        return null;
    }
    public void Save()
    {
        string dataItem = JsonUtility.ToJson(ItemStat_DataSave);
        string dataResource = JsonUtility.ToJson(ResourceStat_DataSave);
        PlayerPrefs.SetString("ItemStat", dataItem);
        PlayerPrefs.SetString("ResourceStat", dataResource);
    }
    public void Load()
    {
        ItemStat_DataSave = JsonUtility.FromJson<DataSave<ItemStat>>(PlayerPrefs.GetString("ItemStat"));
        ResourceStat_DataSave = JsonUtility.FromJson<DataSave<ResourceStat>>(PlayerPrefs.GetString("ResourceStat"));
        Debug.Log(PlayerPrefs.GetString("Data"));
    }
    public List<T1> GetDataListWithType<T, T1>(DataSave<T> data)
    {
        List<T1> dataList = new List<T1>();
        int index = 0;
        for (int i = 0; i < data.results.Count; i++)
        {
            if (data.results[i].GetType().GetField("NAME").GetValue(data.results[i]).Equals(typeof(T1).ToString()))
            {
                FieldInfo id = data.results[i].GetType().GetField("ID");
                if (id != null)
                {
                    id.SetValue(data.results[i], index);
                    index++;
                }
                dataList.Add((T1)(object)data.results[i]);
            }
        }
        return dataList;
    }
}

[System.Serializable]
public class DataSave<T>
{
    public List<T> results;
    public DataSave()
    {
        results = new List<T>();
    }
    public void Add(T b)
    {
        results.Add(b);
    }
}
