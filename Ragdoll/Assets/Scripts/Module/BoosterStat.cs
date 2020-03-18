using UnityEngine;
using System.Collections;

[System.Serializable]
public class BoosterStat : BaseStat
{
    public enum TypeOfBooster
    {
        MAX_HP = 0,
        ATTACK = 1,
        WEAPON = 2,
        REGEN_HP = 3,
        BARRIER = 4,
        OBSTACLE_IMMUMITY = 5,
        CHAIN_LIGHTNING = 6,
    }
    //[System.NonSerialized]
    public BoosterStat(long value, TypeOfBooster typeOfBooster) : base(value)
    {
        this.ID = (int)typeOfBooster;
        this.TYPE = (int)Type.BoosterStat;
        NAME = Type.BoosterStat.ToString();
    }
    public override bool AddPrice(long value = 0)
    {
        if (value > 0)
        {
            VALUE += value;
            return true;
        }
        return false;
    }
}
