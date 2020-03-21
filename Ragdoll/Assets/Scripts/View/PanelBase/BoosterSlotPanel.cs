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
            if (IndexBoosterNeeds[i] < BoosterManager.GetBoosterList().Length)
            {
                BoosterNeeds.Add(BoosterManager.GetBoosterList()[IndexBoosterNeeds[i]]);
            }
            else
            {
                IndexBoosterNeeds[i] = BoosterManager.GetBoosterList().Length - 1;
                BoosterNeeds.Add(BoosterManager.GetBoosterList()[IndexBoosterNeeds[i]]);
            }
        }
        if (SlotListManager is BoosterSlotList)
        {
            BoosterSlotList slotList = SlotListManager as BoosterSlotList;
            slotList.SetupBoosterManager(BoosterManager);
        }
        Setup(BoosterNeeds.ToArray());
    }
    private void Awake()
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
