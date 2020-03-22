using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory instance;
    //private Transform container;
    Dictionary<string, BasePopupSimple> PopupList = new Dictionary<string, BasePopupSimple>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
          //  DontDestroyOnLoad(instance);
        }
        else
        {
           // Destroy(this);
        }
    }

    public void UpdateContainer()
    {
       // if (container == null) container = GameObject.FindGameObjectWithTag(Ke).transform;
    }

    public bool ShowPopup<T>(TypeOfPopup type, T slot = default, List<T> slots = null, string message = null)
    {
        if (PopupList.ContainsKey(type.ToString()))
        {
            BasePopupSimple popup = PopupList[type.ToString()];
            BasePopup<T> _popup = popup as BasePopup<T>;
            _popup.SetupData(slot, slots);
            _popup.transform.SetAsLastSibling();
            _popup.ShowPopup();
            return true;
        }
        bool check = InitPopup(type, slot, slots);
        return check;
    }
    //public BasePopup GetPopup(TypeOfPopup type)
    //{

    //    return null;
    //}
    public bool InitPopup<T>(TypeOfPopup type, T slot,List<T> slots = null)
    {
        // UpdateContainer();
        BasePopupSimple popupNeed = Resources.Load<BasePopupSimple>("Popup/" + type.ToString());
        if (popupNeed == null) return false;
        GameObject obj = Instantiate(popupNeed.gameObject, transform);
        BasePopupSimple popup = obj.GetComponent<BasePopupSimple>();
        if (popup != null)
        {
            PopupList.Add(popup.type.ToString(), popup);
            BasePopup<T> _popup = popup as BasePopup<T>;
            _popup.SetupData(slot, slots);
            _popup.transform.SetAsLastSibling();
            _popup.ShowPopup();
            return true;
        }
        return false;
    }
    public void HideAllPopup()
    {
        foreach(var popup in PopupList.Values)
        {
            popup.HidePopup();
        }
    }

}