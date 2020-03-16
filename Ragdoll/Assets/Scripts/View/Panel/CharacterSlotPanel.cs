﻿using UnityEngine;
using System.Collections;

public class CharacterSlotPanel : _PanelSetup<CharacterSlot, CharacterStat>
{
    ICharacterManager characterManager;
    private void Awake()
    {
        //SlotListManager.OnRightClick += ShowItem;
    }
    private void Start()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        SlotListManager.Setup(characterManager.GetCharacterList());
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
