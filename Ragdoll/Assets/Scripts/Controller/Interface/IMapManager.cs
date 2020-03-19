using UnityEngine;
using System.Collections;

public interface IMapManager
{
    MapDataStat[] MapDataList();
    MapDataStat GetMapWithID(int id);
    MapDataStat HIGHEST_LEVEL
    {
        get;
    }
    MapDataStat CUR_LEVEL
    {
        set;
        get;
    }
    void LoadMaps();

    void SaveMaps();
}
