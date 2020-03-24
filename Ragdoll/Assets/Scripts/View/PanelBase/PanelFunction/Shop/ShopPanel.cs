using UnityEngine;
using System.Collections;

public class ShopPanel : BasePanel
{
    public ShopResourcePanel shopResourcePanel;
    public ShopBoosterPanel shopBoosterPanel;
    public ShopPackPanel shopPackPanel;

  //  public GameObject PackPick_1;
    public GameObject PackPick_2;
    public GameObject PackPick_3;
    IBoosterManager boosterManager;
    IResourceManager resourceManager;
    IShopManager IShopManager;
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
        IShopManager = DIContainer.GetModule<IShopManager>();
        shopResourcePanel.InjectData(resourceManager);
        shopBoosterPanel.InjectData(boosterManager);
        shopPackPanel.InjectData(IShopManager);
    }

    public void ResourceTag()
    {
       // PackPick_1.SetActive(false);
        PackPick_2.SetActive(false);
        PackPick_3.SetActive(true);
       // shopPackPanel.gameObject.SetActive(false);
        shopBoosterPanel.gameObject.SetActive(false);
        shopResourcePanel.gameObject.SetActive(true);
    }
    public void BoosterTag()
    {
       // PackPick_1.SetActive(false);
        PackPick_2.SetActive(true);
        PackPick_3.SetActive(false);

       // shopPackPanel.gameObject.SetActive(false);
        shopBoosterPanel.gameObject.SetActive(true);
        shopResourcePanel.gameObject.SetActive(false);
    }
    public void PackTag()
    {
        //PackPick_1.SetActive(true);
        //PackPick_2.SetActive(false);
        //PackPick_3.SetActive(false);
        //shopPackPanel.gameObject.SetActive(true);
        //shopBoosterPanel.gameObject.SetActive(false);
        //shopResourcePanel.gameObject.SetActive(false);
    }
}
