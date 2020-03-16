using UnityEngine;
using System.Collections;
using System;

// T is itemSlot, T1 is itemStat
[System.Serializable]
public class _SlotListSetup<T,T1> : MonoBehaviour
{
    public _ActionSlotSetup<T,T1>[] slotList;

    public Action<_ActionSlotSetup<T,T1>> OnRightClick;
    public virtual void OnValidate()
    {
        if (slotList == null || slotList.Length == 0) slotList = GetComponentsInChildren<_ActionSlotSetup<T,T1>>();
    }
    public virtual void Setup(T1[] dataBase = null)
    {
        if (slotList == null || slotList.Length == 0) slotList = GetComponentsInChildren<_ActionSlotSetup<T, T1>>();
        if (dataBase != null) SetupSlotList(dataBase);
    }
    void SetupSlotList(T1[] dataBase)
    {
        int i = 0;
        for(; i < dataBase.Length && i < slotList.Length; i++)
        {
            slotList[i].DATA = dataBase[i];
            slotList[i].gameObject.SetActive(true);
            OnRightClick += slotList[i].OnRightClickEvent;
        }
        for(; i < slotList.Length; i++)
        {
            slotList[i].gameObject.SetActive(false);
        }
    }

}
