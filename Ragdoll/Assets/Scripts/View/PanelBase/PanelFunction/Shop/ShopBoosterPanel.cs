using UnityEngine;
using System.Collections;

public class ShopBoosterPanel : BoosterSlotPanel
{
    public SO_BoosterShop soBooster;
    public override void Awake()
    {

    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void Setup(BoosterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public override void SetupAll(IBoosterManager BoosterManager, IResourceManager resourceManager = null)
    {
        Setup(soBooster.boosterList.ToArray());
        SlotListManager.GetType<BoosterSlotList>().SetupBoosterManager(BoosterManager);
    }
}
