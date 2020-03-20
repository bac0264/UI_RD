using UnityEngine;
using System.Collections;

public interface IMapManager
{
    MapDataStat[] MapDataList();
    MapDataStat GetMapWithID(int id);
    MapDataStat HIGHEST_MAP
    {
        get;
    }
    MapDataStat CUR_MAP
    {
        set;
        get;
    }
    bool SetupNextLevel(MapDataStat cur);
    void LoadMaps();

    void SaveMaps();
}
