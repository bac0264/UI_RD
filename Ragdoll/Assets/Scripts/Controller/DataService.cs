using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DataService : IDataService
{
    //DataSave<BaseStat> BaseStat_dataSave;
    DataSave<ItemStat> ItemStat_DataSave;
    DataSave<ResourceStat> ResourceStat_DataSave;
    public DataService()
    {
        if (PlayerPrefs.GetInt("First", 0) == 0)
        {
            ItemStat_DataSave = new DataSave<ItemStat>();
            ResourceStat_DataSave = new DataSave<ResourceStat>();
            int item_count = Enum.GetNames(typeof(ItemStat.TypeOfItem)).Length;
            for (int i = 0; i < item_count; i++)
            {
                ItemStat item = new ItemStat(1, (ItemStat.TypeOfItem)i);
                ItemStat_DataSave.results.Add(item);
            }
            int resource_count = Enum.GetNames(typeof(ResourceStat.TypeOfResource)).Length;
            Debug.Log(resource_count);
            for (int i = 0; i < resource_count; i++)
            {
                ResourceStat.TypeOfResource type = (ResourceStat.TypeOfResource)i;
                Debug.Log(type);
                ResourceStat resource = new ResourceStat(1, (ResourceStat.TypeOfResource)i);
                ResourceStat_DataSave.results.Add(resource);
            }
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
        Debug.Log(dataResource);
    }
    public void Load()
    {
        ItemStat_DataSave = JsonUtility.FromJson<DataSave<ItemStat>>(PlayerPrefs.GetString("ItemStat"));
        ResourceStat_DataSave = JsonUtility.FromJson<DataSave<ResourceStat>>(PlayerPrefs.GetString("ResourceStat"));
        Debug.Log(PlayerPrefs.GetString("ResourceStat"));
        Debug.Log(JsonUtility.ToJson(ResourceStat_DataSave));
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
