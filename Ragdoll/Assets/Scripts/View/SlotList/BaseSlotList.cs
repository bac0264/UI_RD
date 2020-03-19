using UnityEngine;
using System.Collections;

public class BaseSlotList : _SlotListSetup<BaseSlot, BaseStat>
{
    public override void Start()
    {
        base.Start();
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void Setup(BaseStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
}
