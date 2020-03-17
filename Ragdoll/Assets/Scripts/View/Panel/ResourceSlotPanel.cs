using UnityEngine;
using System.Collections;
[System.Serializable]
public class ResourceSlotPanel : _PanelSetup<ResourceSlot, ResourceStat>
{
    IResourceManager resourceManager;
    private void Start()
    {
        resourceManager = DIContainer.GetModule<IResourceManager>();
        Setup(resourceManager.GetResourceList());
    }

    public override void Setup(ResourceStat[] database = null)
    {
        base.Setup(database);
    }
}
