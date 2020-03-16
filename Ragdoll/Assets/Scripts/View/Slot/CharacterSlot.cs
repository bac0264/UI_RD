using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterSlot : _ActionSlotSetup<CharacterSlot, CharacterStat>
{
    public override CharacterStat DATA { get => base.DATA; set => base.DATA = value; }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
