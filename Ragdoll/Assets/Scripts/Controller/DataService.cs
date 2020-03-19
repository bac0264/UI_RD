using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DataService : IDataService
{
    DataSave<BoosterStat> BoosterStat_DataSave;
    DataSave<MapDataStat> MapDataStat_DataSave;
    DataSave<ResourceStat> ResourceStat_DataSave;
    DataSave<CharacterStat> CharacterStat_DataSave;
    public DataService()
    {
        if (PlayerPrefs.GetInt("First", 0) == 0)
        {
            AddResources();
            AddBoosters();
            AddCharacters();
            AddMaps();
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
            ResourceStat resource = new ResourceStat(12, (ResourceStat.TypeOfResource)i);
            ResourceStat_DataSave.Add(resource);
        }
    }
    void AddCharacters()
    {
        CharacterStat_DataSave = new DataSave<CharacterStat>();
        int character_count = Enum.GetNames(typeof(CharacterStat.TypeOfCharacter)).Length;
        Debug.Log(character_count);
        for (int i = 0; i < character_count; i++)
        {
            CharacterStat resource = new CharacterStat((CharacterStat.TypeOfCharacter)i);
            if (i == 0) resource.IsBought = true;
            CharacterStat_DataSave.Add(resource);
        }
    }
    void AddMaps()
    {
        int CurMapCount = 100;
        MapDataStat_DataSave = new DataSave<MapDataStat>();
        int i = 0;
        for (; i < CurMapCount; i++)
        {
            MapDataStat map = new MapDataStat(i);
            if (i == 0)
                map.IS_OPEN = true;
            MapDataStat_DataSave.Add(map);
        }
        Debug.Log(JsonUtility.ToJson(MapDataStat_DataSave));
    }
    void CheckMapInPref()
    {
        int MapInPrefbs = 100;
        MapDataStat_DataSave = new DataSave<MapDataStat>();
        int i = 0;
        for (; i < MapInPrefbs && i < MapDataStat_DataSave.results.Count; i++)
        {
        }
        if (i < MapInPrefbs)
        {
            for (; i < MapInPrefbs; i++)
            {
                MapDataStat map = new MapDataStat(i);
                MapDataStat_DataSave.Add(map);
            }
            Save<MapDataStat>();
            Debug.Log(JsonUtility.ToJson(MapDataStat_DataSave));
        }
    }
    #endregion
    public DataSave<T> GetDataSaveWithType<T>()
    {
        if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) return (DataSave<T>)(object)BoosterStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) return (DataSave<T>)(object)ResourceStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) return (DataSave<T>)(object)CharacterStat_DataSave;
        else if (typeof(T).ToString().Equals(typeof(MapDataStat).ToString())) return (DataSave<T>)(object)MapDataStat_DataSave;
        return null;
    }
    void Save()
    {
        string dataMap = JsonUtility.ToJson(MapDataStat_DataSave);
        string dataBooster = JsonUtility.ToJson(BoosterStat_DataSave);
        string dataResource = JsonUtility.ToJson(ResourceStat_DataSave);
        string DataCharacterUnlock = JsonUtility.ToJson(CharacterStat_DataSave);
        PlayerPrefs.SetString(KeySave.DATA_MAP, dataMap);
        PlayerPrefs.SetString(KeySave.DATA_BOOSTERS, dataBooster);
        PlayerPrefs.SetString(KeySave.DATA_RESOURCES, dataResource);
        PlayerPrefs.SetString(KeySave.DATA_CHARACTERS, DataCharacterUnlock);
    }
    public void Save<T>()
    {
        if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_BOOSTERS, JsonUtility.ToJson(BoosterStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_RESOURCES, JsonUtility.ToJson(ResourceStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_CHARACTERS, JsonUtility.ToJson(CharacterStat_DataSave));
        else if (typeof(T).ToString().Equals(typeof(MapDataStat).ToString())) PlayerPrefs.SetString(KeySave.DATA_MAP, JsonUtility.ToJson(MapDataStat_DataSave));
    }
    public void Load()
    {
        MapDataStat_DataSave = JsonUtility.FromJson<DataSave<MapDataStat>>(PlayerPrefs.GetString(KeySave.DATA_MAP));
        BoosterStat_DataSave = JsonUtility.FromJson<DataSave<BoosterStat>>(PlayerPrefs.GetString(KeySave.DATA_BOOSTERS));
        ResourceStat_DataSave = JsonUtility.FromJson<DataSave<ResourceStat>>(PlayerPrefs.GetString(KeySave.DATA_RESOURCES));
        CharacterStat_DataSave = JsonUtility.FromJson<DataSave<CharacterStat>>(PlayerPrefs.GetString(KeySave.DATA_CHARACTERS));
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
