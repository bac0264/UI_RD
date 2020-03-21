using UnityEngine;
using System.Collections;

public class ShopResourcePanel : _PanelSetup<ResourceSlot,ResourceStat>
{
    public IResourceManager resourceManager;



    public void SetupAll(IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;

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
