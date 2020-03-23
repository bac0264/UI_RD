using UnityEngine;
using System.Collections;

public class BoosterSlotList : _SlotListSetup<BoosterSlot, BoosterStat>
{
    public override void Start()
    {
        base.Start();
    }
    public void SetupBoosterManager(IBoosterManager boosterManager, IResourceManager resourceManager = null)
    {
        foreach(BoosterSlot slot in slotList)
        {
            slot.SetupBoosterManager(boosterManager, resourceManager);
        }
    }
    public override void Setup(BoosterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
