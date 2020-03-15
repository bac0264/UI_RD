using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseStat
{
    public enum Type{
        Resource,
        ITEM,
    }
    [System.NonSerialized]
   // public Type type;

    public int ID;
    public string NAME;
    public long VALUE;
    public int TYPE;
    public BaseStat(long value)
    {
        NAME = "BaseStat";
        this.VALUE = value;
        ID = 0;
    }
    public virtual bool AddPrice() { return false; }
    public virtual bool AddValue(long value)
    {
        if (value > 0)
        {
            VALUE += value;
            return true;
        }
        else return false;
    }
    public virtual bool ReduceValue(long value)
    {
        if (value > 0 && VALUE - value >= 0)
        {
            VALUE -= value;
            return true;
        }
        else return false;
    }
}
