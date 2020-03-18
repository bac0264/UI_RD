using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoosterSlotPanel : _PanelSetup<BoosterSlot, BoosterStat>
{
    IBoosterManager BoosterManager;
    public void SetupAll(IBoosterManager BoosterManager)
    {
        this.BoosterManager = BoosterManager;
        List<BoosterStat> BoosterNeeds = new List<BoosterStat>();
        int[] IndexBoosterNeeds = new int[] { 0, 2, 4 };
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
        Debug.Log(BoosterNeeds.Count);
        if (SlotListManager is BoosterSlotList)
        {
            BoosterSlotList slotList = SlotListManager as BoosterSlotList;
            slotList.SetupBoosterManager(BoosterManager);
        }
        Setup(BoosterNeeds.ToArray());
    }
    private void Awake()
    {
        //SlotListManager.OnRightClick += ShowBooster;
    }
    public override void Setup(BoosterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public void ShowBooster(_ActionSlotSetup<BoosterSlot, BoosterStat> Booster)
    {
    }
}
