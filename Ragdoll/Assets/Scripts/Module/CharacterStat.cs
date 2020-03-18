﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterStat : BaseStat
{
    public enum TypeOfCharacter
    {
        Karen,
        Lima,
        Kubu,
        Alin,
        Likan,
        Exuba,
        Siban,
        Kichun,
        Alias,
        Riki,
        Slack,
        Tommas,
        Akalis,
        Garan,
        Frank,
        Somus,
        Subal,
        Boka,
        Nicle,
        Rasuki,
        Chenxu,
        krakun,
        Toru,
        Luby,
    }
    public int LEVEL;
    public bool IsBought;
    // public bool IsUsed;
    public int VideoUnlock;
    public new readonly long VALUE = 1;
    public CharacterStat(TypeOfCharacter type, bool IsBought = false, int value = 1) : base(value)
    {
        LEVEL = 0;
        TYPE = (int)Type.CharacterStat;
        ID = (int)type;
        IsBought = this.IsBought;
        // IsUsed = this.IsUsed;
        NAME = Type.CharacterStat.ToString();
        VideoUnlock = 5;
    }
}
