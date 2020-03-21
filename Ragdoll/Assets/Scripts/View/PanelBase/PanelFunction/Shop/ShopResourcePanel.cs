using UnityEngine;
using System.Collections;

public class ShopResourcePanel : _PanelSetup<ResourceSlot,ResourceStat>
{
    IResourceManager resourceManager;
    public SO_GoldShop goldShop;
    public void SetupAll(IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
        Setup(goldShop.goldLists.ToArray());
        SlotListManager.GetType<ResourceSlotList>().SetupResourceManager(resourceManager);
    }
    public override void Setup(ResourceStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
