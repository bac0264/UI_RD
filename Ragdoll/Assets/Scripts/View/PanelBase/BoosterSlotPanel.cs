using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoosterSlotPanel : _PanelSetup<BoosterSlot, BoosterStat>
{
    public IBoosterManager BoosterManager;
    public virtual void SetupAll(IBoosterManager BoosterManager)
    {
        this.BoosterManager = BoosterManager;
        List<BoosterStat> BoosterNeeds = new List<BoosterStat>();
        int[] IndexBoosterNeeds = new int[] { 3,1,2 };
        for (int i = 0; i < IndexBoosterNeeds.Length; i++)
        {
            BoosterNeeds.Add(BoosterManager.GetBoosterWithID(IndexBoosterNeeds[i]));
        }
        Setup(BoosterNeeds.ToArray());
        SlotListManager.GetType<BoosterSlotList>().SetupBoosterManager(BoosterManager);
    }
    public virtual void Awake()
    {
        SlotListManager.OnRightClick += PickBooster;
    }
    public override void Setup(BoosterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    void PickBooster(_ActionSlotSetup<BoosterSlot, BoosterStat> Booster)
    {
        if(Booster != null && Booster is BoosterSlot)
        {
            BoosterSlot boosterSlot = Booster as BoosterSlot;
            boosterSlot.PickBooster();
        }
    }
}
