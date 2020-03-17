using UnityEngine;
using System.Collections;

public class BoosterSlotPanel : _PanelSetup<BoosterSlot, BoosterStat>
{
    IBoosterManager BoosterManager;
    private void Start()
    {
        BoosterManager = DIContainer.GetModule<IBoosterManager>();
        Setup(BoosterManager.GetBoosterList());
    }
    private void Awake()
    {
        SlotListManager.OnRightClick += ShowBooster;
    }
    public override void Setup(BoosterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public void ShowBooster(_ActionSlotSetup<BoosterSlot, BoosterStat> Booster)
    {
    }
}
