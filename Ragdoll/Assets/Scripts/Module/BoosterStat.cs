using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public bool IsPick;
    public BoosterStat(long value, TypeOfBooster typeOfBooster) : base(value)
    {
        this.ID = (int)typeOfBooster;
        this.TYPE = (int)Type.BoosterStat;
        NAME = Type.BoosterStat.ToString();
        IsPick = false;
    }
    public BoosterStat(Dictionary<string, string> data) : base(data)
    {
        NAME = Type.BoosterStat.ToString();
        this.TYPE = (int)Type.BoosterStat;
    }
    public override bool AddPrice()
    {
        Debug.Log("Character");
        if (VALUE > 0)
        {
            Debug.Log("Character");
            IBoosterManager booster = DIContainer.GetModule<IBoosterManager>();
            booster.GetBoosterWithID(ID).VALUE += VALUE;
            booster.SaveBoosters();
            return true;
        }
        return true;
    }
}
