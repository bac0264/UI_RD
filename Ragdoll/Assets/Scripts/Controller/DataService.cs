﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DataService : IDataService
{
    UserStat DataUser;
    DataSave<DataShop> DataShop_DataSave;
    DataSave<BoosterStat> BoosterStat_DataSave;
    DataSave<MapDataStat> MapDataStat_DataSave;
    DataSave<ResourceStat> ResourceStat_DataSave;
    DataSave<CharacterStat> CharacterStat_DataSave;
    SoundMusicLanguageStat DataSoundMusicLanguage;
    public DataService()
    {
        if (PlayerPrefs.GetInt("First", 0) == 0)
        {
            PlayerPrefs.SetInt("First", 1);
            AddSoundMusicLanguage();
            AddCharacters();
            AddResources();
            AddBoosters();
            AddDataUser();
            AddShops();
            AddMaps();
            Save();
        }
        else
            Load();
    }

    // For the first
    #region
    void AddDataUser()
    {
        DataUser = new UserStat(0, "BacDzai", 0);
    }
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
    }
    void AddSoundMusicLanguage()
    {
        int language = 2;  /*(int)Application.systemLanguage;*/
        DataSoundMusicLanguage = new SoundMusicLanguageStat(true, true, language);
    }
    void AddShops()
    {
        DataShop_DataSave = new DataSave<DataShop>();
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
        if (typeof(T).ToString().Equals(typeof(DataShop).ToString())) return (DataSave<T>)(object)DataShop_DataSave;
        else if (typeof(T).ToString().Equals(typeof(MapDataStat).ToString())) return (DataSave<T>)(object)MapDataStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) return (DataSave<T>)(object)BoosterStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) return (DataSave<T>)(object)ResourceStat_DataSave;
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) return (DataSave<T>)(object)CharacterStat_DataSave;
        return null;
    }
    void Save()
    {
        string dataUser = JsonUtility.ToJson(DataUser);
        string dataShop = JsonUtility.ToJson(DataShop_DataSave);
        string dataMap = JsonUtility.ToJson(MapDataStat_DataSave);
        string dataBooster = JsonUtility.ToJson(BoosterStat_DataSave);
        string dataResource = JsonUtility.ToJson(ResourceStat_DataSave);
        string dataProfile = JsonUtility.ToJson(DataSoundMusicLanguage);
        string dataCharacterUnlock = JsonUtility.ToJson(CharacterStat_DataSave);

        PlayerPrefs.SetString(KeySave.DATA_MAP, dataMap);
        PlayerPrefs.SetString(KeySave.DATA_USER, dataUser);
        PlayerPrefs.SetString(KeySave.DATA_SHOPS, dataShop);
        PlayerPrefs.SetString(KeySave.DATA_PROFILE, dataProfile);
        PlayerPrefs.SetString(KeySave.DATA_BOOSTERS, dataBooster);
        PlayerPrefs.SetString(KeySave.DATA_RESOURCES, dataResource);
        PlayerPrefs.SetString(KeySave.DATA_CHARACTERS, dataCharacterUnlock);
    }
    public void Save<T>()
    {
        if (typeof(T).ToString().Equals(typeof(UserStat).ToString())) PlayerPrefs.SetString(KeySave.DATA_USER, JsonUtility.ToJson(DataUser));
        else if (typeof(T).ToString().Equals(typeof(DataShop).ToString())) PlayerPrefs.SetString(KeySave.DATA_SHOPS, JsonUtility.ToJson(DataShop_DataSave));
        else if (typeof(T).ToString().Equals(typeof(MapDataStat).ToString())) PlayerPrefs.SetString(KeySave.DATA_MAP, JsonUtility.ToJson(MapDataStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.BoosterStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_BOOSTERS, JsonUtility.ToJson(BoosterStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.ResourceStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_RESOURCES, JsonUtility.ToJson(ResourceStat_DataSave));
        else if (typeof(T).ToString().Equals(BaseStat.Type.CharacterStat.ToString())) PlayerPrefs.SetString(KeySave.DATA_CHARACTERS, JsonUtility.ToJson(CharacterStat_DataSave));
        else if (typeof(T).ToString().Equals(typeof(SoundMusicLanguageStat).ToString())) PlayerPrefs.SetString(KeySave.DATA_PROFILE, JsonUtility.ToJson(DataSoundMusicLanguage));
    }
    public void Load()
    {
        DataUser = JsonUtility.FromJson<UserStat>(PlayerPrefs.GetString(KeySave.DATA_USER));
        DataShop_DataSave = JsonUtility.FromJson<DataSave<DataShop>>(PlayerPrefs.GetString(KeySave.DATA_SHOPS));
        MapDataStat_DataSave = JsonUtility.FromJson<DataSave<MapDataStat>>(PlayerPrefs.GetString(KeySave.DATA_MAP));
        BoosterStat_DataSave = JsonUtility.FromJson<DataSave<BoosterStat>>(PlayerPrefs.GetString(KeySave.DATA_BOOSTERS));
        DataSoundMusicLanguage = JsonUtility.FromJson<SoundMusicLanguageStat>(PlayerPrefs.GetString(KeySave.DATA_PROFILE));
        ResourceStat_DataSave = JsonUtility.FromJson<DataSave<ResourceStat>>(PlayerPrefs.GetString(KeySave.DATA_RESOURCES));
        CharacterStat_DataSave = JsonUtility.FromJson<DataSave<CharacterStat>>(PlayerPrefs.GetString(KeySave.DATA_CHARACTERS));
    }

    public UserStat GetUserInfo()
    {
        return DataUser;
    }

    public SoundMusicLanguageStat GetDataProfile()
    {
        return DataSoundMusicLanguage;
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
