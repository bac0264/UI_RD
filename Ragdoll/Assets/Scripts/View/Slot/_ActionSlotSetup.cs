using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

[System.Serializable]
public class _ActionSlotSetup<T,T1> : MonoBehaviour
{
    private T1 data;
    public Text TXT_VALUE;
    public Image IMG_ICON;
    public Image IMG_BG;
    public Action<_ActionSlotSetup<T, T1>> OnRightClickEvent;
    public virtual T1 DATA
    {
        set
        {
            data = value;
        }
        get { return data; }
    }
    //  public virtual AddData(T data)
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Right || eventData.clickCount > 0))
        {
            if (OnRightClickEvent != null && this != null)
            {
                OnRightClickEvent(this);
            }
        }

    }
}