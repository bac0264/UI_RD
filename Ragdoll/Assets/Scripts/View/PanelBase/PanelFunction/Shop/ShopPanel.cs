using UnityEngine;
using System.Collections;

public class ShopPanel : BasePanel
{
    public ShopResourcePanel shopResourcePanel;
    IResourceManager resourceManager;
    public override void OnValidate()
    {
        base.OnValidate();
        if (shopResourcePanel == null) shopResourcePanel = GetComponentInChildren<ShopResourcePanel>();
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }
    private void Start()
    {
        resourceManager = DIContainer.GetModule<IResourceManager>();
        SetupData();
    }
    public void SetupData()
    {
        shopResourcePanel.SetupAll(resourceManager);
    }
}
