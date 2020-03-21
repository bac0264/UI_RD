using UnityEngine;
using System.Collections;

public class ResourceSlotList : _SlotListSetup<ResourceSlot, ResourceStat>
{
    public void SetupResourceManager(IResourceManager resourceManager)
    {
        foreach (ResourceSlot slot in slotList)
        {
            slot.SetupResourceManager(resourceManager);
        }
    }
    public override void Start()
    {
        base.Start();
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void Setup(ResourceStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
}
