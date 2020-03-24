using UnityEngine;
using System.Collections;

public class ShopSlotList : MonoBehaviour
{
    public PackSlot[] packSlots;

    public bool CheckPacks(IShopManager shopManager)
    {
        bool check = false;
        for (int j = 0; j < packSlots.Length; j++)
        {
            if (packSlots[j].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        if (!check)
        {
            return true;
        }
        return false;
    }
    private void OnValidate()
    {
        if (packSlots == null || packSlots.Length == 0) packSlots = GetComponentsInChildren<PackSlot>();
    }
    public void SetupData(DataPack[] dataPacks, IShopManager shopManager)
    {
        int i = 0;
        for (; i < packSlots.Length && i < dataPacks.Length; i++)
        {
            packSlots[i].DATA_PACK = dataPacks[i];
            packSlots[i].SetupShopManager(shopManager);
            packSlots[i].gameObject.SetActive(true);
        }
        for (; i < packSlots.Length ; i++)
        {
            packSlots[i].gameObject.SetActive(false);
        }
        DataShop[] dataShop = shopManager.GetDataShopList();
        int k = 0;
        for (; k < dataShop.Length; k++)
        {
            for (int j = 0; j < packSlots.Length; j++)
            {
                if (packSlots[j].DATA_PACK.ID == dataShop[k].id)
                {
                    packSlots[j].gameObject.SetActive(false);
                }
            }
        }
    }
}
