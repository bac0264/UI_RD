using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopPopup : BasePopup<BaseStat>
{
    public BaseSlotList baseSlotList;
    private void OnValidate()
    {
        if (baseSlotList == null) baseSlotList = GetComponentInChildren<BaseSlotList>();
    }

    public override void SetupData(BaseStat _data, List<BaseStat> data = null, string message = null)
    {
        if (_data == null && data != null) baseSlotList.Setup(data.ToArray());
        else if (_data != null && data == null)
        {
            data = new List<BaseStat>();
            data.Add(_data);
            baseSlotList.Setup(data.ToArray());
        }
    }
}
