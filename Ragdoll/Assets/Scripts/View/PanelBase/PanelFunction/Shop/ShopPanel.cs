using UnityEngine;
using System.Collections;

public class ShopPanel : BasePanel
{
    public ShopResourcePanel shopResourcePanel;
    public ShopBoosterPanel shopBoosterPanel;
    public ShopPackPanel shopPackPanel;


    IBoosterManager boosterManager;
    IResourceManager resourceManager;

    public override void OnValidate()
    {
        base.OnValidate();
        if (shopResourcePanel == null) shopResourcePanel = GetComponentInChildren<ShopResourcePanel>();
        if (shopBoosterPanel == null) shopBoosterPanel = GetComponentInChildren<ShopBoosterPanel>();
        if (shopPackPanel == null) shopPackPanel = GetComponentInChildren<ShopPackPanel>();
    }

    public override void ShowPanel()
    {
        SetupData();
        ResourceTag();
        base.ShowPanel();
    }
    //private void Start()
    //{
    //    SetupData();
    //}
    public void SetupData()
    {
        resourceManager = DIContainer.GetModule<IResourceManager>();
        boosterManager = DIContainer.GetModule<IBoosterManager>();
        shopResourcePanel.SetupAll(resourceManager);
        shopBoosterPanel.SetupAll(boosterManager);
        shopPackPanel.SetupAll();
    }

    public void ResourceTag()
    {
        shopPackPanel.gameObject.SetActive(false);
        shopBoosterPanel.gameObject.SetActive(false);
        shopResourcePanel.gameObject.SetActive(true);
    }
    public void BoosterTag()
    {
        shopPackPanel.gameObject.SetActive(false);
        shopBoosterPanel.gameObject.SetActive(true);
        shopResourcePanel.gameObject.SetActive(false);
    }
    public void PackTag()
    {
        shopPackPanel.gameObject.SetActive(true);
        shopBoosterPanel.gameObject.SetActive(false);
        shopResourcePanel.gameObject.SetActive(false);
    }
}
