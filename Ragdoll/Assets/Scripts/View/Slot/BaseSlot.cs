using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseSlot : _ActionSlotSetup<BaseSlot,BaseStat>
{
    public override BaseStat DATA { 
        get => base.DATA;
        set
        {
            base.DATA = value;

            TXT_VALUE.text = DATA.VALUE.ToString();

            if (DATA is ItemStat)
            {
                DATA.TYPE = (int)BaseStat.Type.ITEM;
            }
            else if (DATA is ResourceStat)
            {
                DATA.TYPE = (int)BaseStat.Type.Resource;
            }
            IMG_ICON.sprite = BaseStatDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            IMG_BG.sprite = BaseStatDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
        }        
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
