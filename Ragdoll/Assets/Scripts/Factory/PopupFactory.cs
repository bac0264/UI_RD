using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory instance;
    private Transform container;
    Dictionary<string, BasePopup> PopupList = new Dictionary<string, BasePopup>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void UpdateContainer()
    {
      //  if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }

    public bool ShowPopup<T,T1>(BasePopup.TypeOfPopup type, string message = null, _ActionSlotSetup<T,T1> slot = null)
    {
        if (PopupList.ContainsKey(type.ToString()))
        {
            BasePopup popup = PopupList[type.ToString()];
            popup.SetupData(slot);
            popup.ShowPopup();         
        }
        bool check = InitPopup<T,T1>(type);
        return check;
    }
    public BasePopup GetPopup(BasePopup.TypeOfPopup type)
    {

        return null;
    }
    public bool InitPopup<T,T1>(BasePopup.TypeOfPopup type, _ActionSlotSetup<T, T1> slot = null)
    {
        UpdateContainer();
        BasePopup popupNeed = Resources.Load<BasePopup>("Popup/" + type.ToString());
        if (popupNeed == null) return false;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null)
        {
            PopupList.Add(popup.type.ToString(), popup);
            popup.transform.SetAsLastSibling();
            popup.ShowPopup();
            popup.SetupData(slot);
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