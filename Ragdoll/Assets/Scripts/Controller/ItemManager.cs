using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : IItemManager
{
    IDataService dataService;
    DataSave<ItemStat> dataSave;
    public ItemManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadItems();
    }

    public ItemStat GetItemWithID(int id)
    {
        if (id < dataSave.results.Count) return dataSave.results[id];
        return null;
    }

    public void LoadItems()
    {
        dataSave = dataService.GetDataSaveWithType<ItemStat>();
    }

    public void SaveItems()
    {
        PlayerPrefs.SetString("ItemStat", JsonUtility.ToJson(dataSave));
    }

    // Start is called before the first frame update
}
