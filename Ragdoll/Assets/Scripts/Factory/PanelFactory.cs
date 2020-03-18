﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PanelFactory : MonoBehaviour
{
    public static PanelFactory instance;
    private Transform container;
    Dictionary<string, BasePanel> panelList = new Dictionary<string, BasePanel>();
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

    public bool ShowPanel(PanelType type, string message = null)
    {
        if (panelList.ContainsKey(type.ToString()))
        {
            BasePanel panel = panelList[type.ToString()];
           // panel.Setup();
            panel.ShowPanel();
            return true;
        }
        bool check = InitPanel(type);
        return check;
    }
    public BasePopup GetPopup(BasePopup.TypeOfPopup type)
    {

        return null;
    }
    public bool InitPanel(PanelType type)
    {
        UpdateContainer();
        Debug.Log("run");
        Debug.Log("Panel/" + type.ToString());
        BasePanel panelNeed = Resources.Load<BasePanel>("Panel/" + type.ToString());
        if (panelNeed == null) return false;
        Debug.Log(panelNeed);
        GameObject obj = Instantiate(panelNeed.gameObject, container);
        BasePanel panel = obj.GetComponent< BasePanel>();
        if (panel != null)
        {
            Debug.Log(panel);
            panelList.Add(panel.panelType.ToString(), panel);
            panel.transform.SetAsLastSibling();
           // panel.Setup();
            panel.ShowPanel();
            return true;
        }
        Debug.Log(false);
        return false;
    }

}