using UnityEngine;
using System.Collections;

public class ShopPackPanel : MonoBehaviour
{
    public ShopSlotList shopSlotList;
    public SO_PackShop soPackShop;
    IShopManager shopManager;
    private void Start()
    {
        CheckShowPacks();
    }
    public void CheckShowPacks()
    {
        bool check = shopSlotList.CheckPacks(shopManager);
        if (check) gameObject.SetActive(false);
    }
    private void OnValidate()
    {
        if (shopSlotList == null) shopSlotList = GetComponentInChildren<ShopSlotList>();
    }
    public void InjectData(IShopManager shopManager)
    {
        this.shopManager = shopManager;
        shopSlotList.SetupData(soPackShop.PackDatas.ToArray(), shopManager);
    }
}
