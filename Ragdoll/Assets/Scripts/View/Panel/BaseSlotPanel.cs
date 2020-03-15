using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSlotPanel : _PanelSetup<BaseSlot,BaseStat>
{
    public SOPrice price;
    private void Start()
    {

    }
    public override void Setup(BaseStat[] database)
    {
        base.Setup(database);
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
