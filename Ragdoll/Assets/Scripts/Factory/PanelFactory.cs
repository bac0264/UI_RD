using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PanelFactory : MonoBehaviour
{
    public static PanelFactory instance;
    private Transform container;
    Dictionary<string, object> panelList = new Dictionary<string, object>();
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
        if (container == null) container = GameObject.FindGameObjectWithTag("UIFunctionContainer").transform;
    }

    public bool ShowPanel<T, T1>(PanelType type, string message = null)
    {
        if (panelList.ContainsKey(type.ToString()))
        {
            _PanelSetup<T, T1> panel = (_PanelSetup<T, T1>)panelList[type.ToString()];
            panel.Setup();
            panel.ShowPanel();
            return true;
        }
        bool check = InitPanel<T, T1>(type);
        return check;
    }
    public BasePopup GetPopup(BasePopup.TypeOfPopup type)
    {

        return null;
    }
    public bool InitPanel<T, T1>(PanelType type)
    {
        UpdateContainer();
        Debug.Log("run");
        Debug.Log("Panel/" + type.ToString());
        _PanelSetup<T, T1> panelNeed = Resources.Load<_PanelSetup<T, T1>>("Panel/" + type.ToString());
        if (panelNeed == null) return false;
        Debug.Log(panelNeed);
        GameObject obj = Instantiate(panelNeed.gameObject, container);
        _PanelSetup<T, T1> panel = obj.GetComponent<_PanelSetup<T, T1>>();
        if (panel != null)
        {
            Debug.Log(panel);
            panelList.Add(panel.panelType.ToString(), panel);
            panel.transform.SetAsLastSibling();
            panel.Setup();
            panel.ShowPanel();
            return true;
        }
        Debug.Log(false);
        return false;
    }

}