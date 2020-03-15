using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : _ActionSlotSetup<ItemSlot, ItemStat>
{

    public override ItemStat DATA { 
        get => base.DATA; set
        {
            base.DATA = value;

            TXT_VALUE.text = DATA.VALUE.ToString();
            IMG_ICON.sprite = BaseStatDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            IMG_BG.sprite = BaseStatDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
        }
    
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
