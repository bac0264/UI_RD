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
    public MapDataStat HIGHEST_MAP
    {
        get
        {
            return JsonUtility.FromJson<MapDataStat>(PlayerPrefs.GetString("HighestMap"));
        }
    }
    public MapDataStat CUR_MAP
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
                    MapDataStat highest = HIGHEST_MAP;
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
                CUR_MAP = dataSave.results[0];
            }
        }
    }
    public void SaveMaps()
    {
        dataService.Save<MapDataStat>();
    }

    public bool SetupNextLevel(MapDataStat cur)
    {
        if (cur.ID >= dataSave.results[dataSave.results.Count - 1].ID || cur.ID < HIGHEST_MAP.ID)
        {
            CUR_MAP = cur;
            return false;
        }
        MapDataStat next = GetMapWithID(cur.ID + 1);
        next.IS_OPEN = true;
        CUR_MAP = next;
        SaveMaps();
        return true;
    }
}