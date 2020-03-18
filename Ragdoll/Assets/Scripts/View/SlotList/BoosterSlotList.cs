using UnityEngine;
using System.Collections;

public class BoosterSlotList : _SlotListSetup<BoosterSlot, BoosterStat>
{
    public void SetupBoosterManager(IBoosterManager boosterManager)
    {
        foreach(BoosterSlot slot in slotList)
        {
            slot.SetupBoosterManager(boosterManager);
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
