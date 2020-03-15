using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemStat : BaseStat
{
    public enum TypeOfItem
    {
        Attack,
        Defense,
    }
    //[System.NonSerialized]
    public ItemStat(long value, TypeOfItem typeOfItem) : base(value)
    {
        this.ID = (int)typeOfItem;
        this.TYPE = (int) Type.ITEM;
        NAME = "ItemStat";
    }
}
