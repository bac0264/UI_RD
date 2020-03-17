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

            if(TXT_VALUE != null) TXT_VALUE.text = DATA.VALUE.ToString();
            if (IMG_ICON != null)
            {
                IMG_ICON.sprite = BaseStatDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
                IMG_ICON.SetNativeSize();
                IMG_ICON.rectTransform.pivot = new Vector2(0.5f, 0.4f);
            }
            if(IMG_BG != null) IMG_BG.sprite = BaseStatDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
        }        
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
