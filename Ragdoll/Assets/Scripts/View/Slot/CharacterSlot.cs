using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSlot : _ActionSlotSetup<CharacterSlot, CharacterStat>
{
    public Text CHARACTER_NAME;
    public override CharacterStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (TXT_VALUE != null)
                TXT_VALUE.text = DATA.VALUE.ToString();
            if (IMG_ICON != null)
            {
                IMG_ICON.sprite = SpriteDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            }
            if (IMG_BG != null)
                IMG_BG.sprite = SpriteDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
            if (CHARACTER_NAME != null)
                CHARACTER_NAME.text = ((CharacterStat.TypeOfCharacter)DATA.ID).ToString();
        }
    }
}
