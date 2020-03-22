using UnityEngine;
using System.Collections;

public class ShopSlotList : MonoBehaviour
{
    public PackSlot[] packSlots;

    private void OnValidate()
    {
        if (packSlots == null || packSlots.Length == 0) packSlots = GetComponentsInChildren<PackSlot>();
    }
    public void SetupData(DataPack[] dataPacks)
    {
        int i = 0;
        for (; i < packSlots.Length && i < dataPacks.Length; i++)
        {
            packSlots[i].DATA_PACK = dataPacks[i];
            packSlots[i].gameObject.SetActive(true);
        }
        for (; i < packSlots.Length ; i++)
        {
            packSlots[i].gameObject.SetActive(false);
        }
    }
}
