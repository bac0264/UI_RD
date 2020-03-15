using UnityEngine;
using System.Collections;

public class _PanelSetup<T,T1> : MonoBehaviour
{
    public _SlotListSetup<T, T1> SlotListManager;

    public virtual void Setup(T1[] dataBase = null)
    {
        if (SlotListManager == null) SlotListManager = GetComponentInChildren<_SlotListSetup<T, T1>>();
        if (SlotListManager != null) SlotListManager.Setup(dataBase);
    }
    public virtual void OnValidate()
    {
        if (SlotListManager == null) SlotListManager = GetComponentInChildren<_SlotListSetup<T, T1>>();
    }
}
