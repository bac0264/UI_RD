using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterManager : IBoosterManager
{
    IDataService dataService;
    DataSave<BoosterStat> dataSave;
    public BoosterManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadBoosters();
    }

    public BoosterStat[] GetBoosterList()
    {
        if (dataSave != null) return dataSave.results.ToArray();
        return null;
    }

    public BoosterStat GetBoosterWithID(int id)
    {
        if (id < dataSave.results.Count) return dataSave.results[id];
        return null;
    }

    public void LoadBoosters()
    {
        dataSave = dataService.GetDataSaveWithType<BoosterStat>();
    }

    public void SaveBoosters()
    {
        PlayerPrefs.SetString("BoosterStat", JsonUtility.ToJson(dataSave));
    }

    // Start is called before the first frame update
}
