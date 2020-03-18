using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseStat
{
    public enum Type{
        ResourceStat,
        BoosterStat,
        CharacterStat,
    }

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
    public BaseStat(Dictionary<string, string> data)
    {
        int.TryParse(data["ID"], out ID);
        long.TryParse(data["VALUE"], out VALUE);
        int.TryParse(data["TYPE"], out TYPE);
        NAME = data["NAME"];
    }


    public virtual bool AddPrice(long value = 0) { return false; }
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
