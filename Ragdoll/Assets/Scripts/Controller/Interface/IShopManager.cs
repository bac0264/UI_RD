using UnityEngine;
using System.Collections;

public interface IShopManager
{
    DataShop[] GetDataShopList();
    void AddPackRecieving(DataShop data);
    void SaveShops();
    void LoadShops();
}

[System.Serializable]

public class DataShop
{
    public int id;
    public DataShop(int id)
    {
        this.id = id;
    }
}