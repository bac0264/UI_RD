using UnityEngine;
using System.Collections;

public class MapManager : IMapManager
{
    IDataService dataService;
    DataSave<MapDataStat> dataSave;
    MapDataStat currentLevel;
    public MapManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadMaps();
    }
    public MapDataStat HIGHEST_LEVEL
    {
        get
        {
            return JsonUtility.FromJson<MapDataStat>(PlayerPrefs.GetString("HighestMap"));
        }
    }
    public MapDataStat CUR_LEVEL
    {
        get
        {
            return JsonUtility.FromJson<MapDataStat>(PlayerPrefs.GetString("CurrentMap"));
        }
        set
        {
            if (value != null)
            {
                currentLevel = value;
                if (currentLevel != null)
                {
                    PlayerPrefs.SetString("CurrentMap", JsonUtility.ToJson(currentLevel));
                    MapDataStat highest = HIGHEST_LEVEL;
                    if (highest == null || highest.ID < currentLevel.ID)
                    {
                        PlayerPrefs.SetString("HighestMap", JsonUtility.ToJson(currentLevel));
                    }
                }
            }
        }
    }

    public MapDataStat GetMapWithID(int id)
    {
        if (id < dataSave.results.Count) return dataSave.results[id];
        return null;
    }

    public MapDataStat[] MapDataList()
    {
        if (dataSave != null) return dataSave.results.ToArray();
        return null;
    }
    public void LoadMaps()
    {
        dataSave = dataService.GetDataSaveWithType<MapDataStat>();
        if (PlayerPrefs.GetString("CurrentMap", "") == "")
        {
            if (dataSave.results.Count > 0)
            {
                CUR_LEVEL = dataSave.results[0];
            }
        }
    }
    public void SaveMaps()
    {
        dataService.Save<MapDataStat>();
    }

}