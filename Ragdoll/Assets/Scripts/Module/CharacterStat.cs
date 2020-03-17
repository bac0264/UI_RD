using UnityEngine;
using System.Collections;

public class CharacterStat : BaseStat
{
    public enum TypeOfCharacter
    {
        Pantheon,
        Lucian,
        Syndra,
        Jhin,
        Jinx,
        Nassus,
        Chogath,
        Leesin,
        Oriana,
        Neeko,
        Zed,
        Kennen,
    }
    public bool IsBought;
    public bool IsUsed;

    public new readonly long VALUE = 1;
    public CharacterStat(TypeOfCharacter type, bool IsBought = false,bool IsUsed = false, int value = 1): base(value)
    {
        TYPE = (int)Type.CharacterStat;
        ID = (int)type;
        IsBought = this.IsBought;
        IsUsed = this.IsUsed;
        NAME = Type.CharacterStat.ToString(); ;
    }
}
