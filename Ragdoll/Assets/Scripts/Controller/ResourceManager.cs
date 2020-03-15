using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class ResourceManager : IResourceManager
{
    IDataService dataService;
    DataSave<ResourceStat> dataSave;
    public ResourceManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadResources();
    }

    public ResourceStat GetItemWithID(int id)
    {
        if (id < dataSave.results.Count) return dataSave.results[id];
        return null;
    }

    public ResourceStat[] GetResourceList()
    {
        if (dataSave != null) return dataSave.results.ToArray();
        return null;
    }

    public void LoadResources()
    {
        dataSave = dataService.GetDataSaveWithType<ResourceStat>();
    }

    public void SaveResources()
    {
        PlayerPrefs.SetString("ResourceStat", JsonUtility.ToJson(dataSave));
    }
}
