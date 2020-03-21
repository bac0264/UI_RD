using UnityEngine;
using System.Collections;
[System.Serializable]
public class ResourceSlotPanel : _PanelSetup<ResourceSlot, ResourceStat>
{
    IResourceManager resourceManager;
    SO_GoldShop soGoldShop;
    private void Start()
    {
        resourceManager = DIContainer.GetModule<IResourceManager>();
        Setup(resourceManager.GetResourceList());
        SlotListManager.GetType<ResourceSlotList>().SetupResourceManager(resourceManager);
    }

    public override void Setup(ResourceStat[] database = null)
    {
        base.Setup(database);
    }
}
