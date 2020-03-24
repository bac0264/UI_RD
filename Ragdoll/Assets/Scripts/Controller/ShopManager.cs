using UnityEngine;
using System.Collections;

public class ShopManager : IShopManager
{
    IDataService dataService;
    DataSave<DataShop> dataSave;
    public ShopManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadShops();
    }

    public void AddPackRecieving(DataShop data)
    {
        if (data != null && dataSave != null)
            dataSave.Add(data);
    }

    public DataShop[] GetDataShopList()
    {
        if (dataSave != null) return dataSave.results.ToArray();
        return null;
    }

    public void LoadShops()
    {
        dataSave = dataService.GetDataSaveWithType<DataShop>();
    }

    public void SaveShops()
    {
        dataService.Save<DataShop>();
    }

    // Use this for initialization
}
