using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DataService : IDataService
{
    public const string DATA_BoosterS = "BoosterStat";
    public const string DATA_RESOURCES = "ResourceStat";
    public const string DATA_CHARACTERS = "CharacterStat";
    //DataSave<BaseStat> BaseStat_dataSave;
    DataSave<BoosterStat> BoosterStat_DataSave;
    DataSave<ResourceStat> ResourceStat_DataSave;
    DataSave<CharacterStat> CharacterStat_DataSave;
    public DataService()
    {
        if (PlayerPrefs.GetInt("First", 0) == 0)
        {
            AddResources();
            AddBoosters();
            AddCharacters();
            Save();
            PlayerPrefs.SetInt("First", 1);
        }
        else
            Load();
    }
    // For the first
    #region
    void AddBoosters()
    {
        BoosterStat_DataSave = new DataSave<BoosterStat>();
        int Booster_count = Enum.GetNames(typeof(BoosterStat.TypeOfBooster)).Length;
        for (int i = 0; i < Booster_count; i++)
        {
            BoosterStat Booster = new BoosterStat(1, (BoosterStat.TypeOfBooster)i);
            BoosterStat_DataSave.Add(Booster);
        }
    }
    void AddResources()
    {
        ResourceStat_DataSave = new DataSave<ResourceStat>();
        int resource_count = Enum.GetNames(typeof(ResourceStat.TypeOfResource)).Length;
        for (int i = 0; i < resource_count; i++)
        {
            ResourceStat resource = new ResourceStat(1, (ResourceStat.TypeOfResource)i);
            ResourceStat_DataSave.Add(resource);
        }
    }
    void AddCharacters()
    {
        CharacterStat_DataSave = new DataSave<CharacterStat>();
        int character_count = Enum.GetNames(typeof(CharacterStat.TypeOfCharacter)).Length;
        for (int i = 0; i < character_count; i++)
        {
            CharacterStat resource = new CharacterStat((CharacterStat.TypeOfCharacter)i);
            CharacterStat_DataSave.Add(resource);
        }
    }
    #endregion
    public DataSave<T> GetDataSaveWithType<T>()
    {
        if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) return (DataSave<T>)(object)BoosterStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) return (DataSave<T>)(object)ResourceStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) return (DataSave<T>)(object)CharacterStat_DataSave;
        return null;
    }
    void Save()
    {
        string dataBooster = JsonUtility.ToJson(BoosterStat_DataSave);
        string dataResource = JsonUtility.ToJson(ResourceStat_DataSave);
        string dataCharacter = JsonUtility.ToJson(CharacterStat_DataSave);
        PlayerPrefs.SetString(DATA_BoosterS, dataBooster);
        PlayerPrefs.SetString(DATA_RESOURCES, dataResource);
        PlayerPrefs.SetString(DATA_CHARACTERS, dataCharacter);
    }
    public void Save<T>()
    {
        if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) PlayerPrefs.SetString(DATA_BoosterS, JsonUtility.ToJson(BoosterStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) PlayerPrefs.SetString(DATA_BoosterS, JsonUtility.ToJson(ResourceStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) PlayerPrefs.SetString(DATA_BoosterS, JsonUtility.ToJson(CharacterStat_DataSave));
    }
    public void Load()
    {
        BoosterStat_DataSave = JsonUtility.FromJson<DataSave<BoosterStat>>(PlayerPrefs.GetString(DATA_BoosterS));
        ResourceStat_DataSave = JsonUtility.FromJson<DataSave<ResourceStat>>(PlayerPrefs.GetString(DATA_RESOURCES));
        CharacterStat_DataSave = JsonUtility.FromJson<DataSave<CharacterStat>>(PlayerPrefs.GetString(DATA_CHARACTERS));
    }
    //public List<T1> GetDataListWithType<T, T1>(DataSave<T> data)
    //{
    //    List<T1> dataList = new List<T1>();
    //    int index = 0;
    //    for (int i = 0; i < data.results.Count; i++)
    //    {
    //        if (data.results[i].GetType().GetField("NAME").GetValue(data.results[i]).Equals(typeof(T1).ToString()))
    //        {
    //            FieldInfo id = data.results[i].GetType().GetField("ID");
    //            if (id != null)
    //            {
    //                id.SetValue(data.results[i], index);
    //                index++;
    //            }
    //            dataList.Add((T1)(object)data.results[i]);
    //        }
    //    }
    //    return dataList;
    //}
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
