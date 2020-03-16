using UnityEngine;
using System.Collections;

public class CharacterStat : MonoBehaviour
{
    public enum Type
    {
        Pantheon,
        Lucian,
        Syndra,
    }

    public int ID;
    public bool IsBought;
    public bool IsUsed;

    public CharacterStat(Type type, bool IsBought,bool IsUsed)
    {
        ID = (int)type;
        IsBought = this.IsBought;
        IsUsed = this.IsUsed;
    }

}
