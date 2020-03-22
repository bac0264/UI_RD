using UnityEngine;
using System.Collections;

public class ShopPackPanel : MonoBehaviour
{
    public ShopSlotList shopSlotList;
    public SO_PackShop soPackShop;
    private void OnValidate()
    {
        if (shopSlotList == null) shopSlotList = GetComponentInChildren<ShopSlotList>();
    }
    public void SetupAll()
    {
        shopSlotList.SetupData(soPackShop.PackDatas.ToArray());
    }
}
