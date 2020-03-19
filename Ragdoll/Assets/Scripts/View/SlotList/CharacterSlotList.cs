using UnityEngine;
using System.Collections;

public class CharacterSlotList : _SlotListSetup<CharacterSlot, CharacterStat>
{
    public override void Start()
    {
        base.Start();
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void Setup(CharacterStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
}
