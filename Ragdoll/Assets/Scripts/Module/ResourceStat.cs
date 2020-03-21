using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ResourceStat : BaseStat
{
    public enum TypeOfResource
    {
        GOLD = 0,
        EXP = 1,
    }
    public ResourceStat(long value, TypeOfResource typeOfResource) : base(value)
    {
        this.ID = (int)typeOfResource;
        NAME = Type.ResourceStat.ToString();
        this.TYPE = (int)Type.ResourceStat;
    }
    public ResourceStat(Dictionary<string, string> data) : base(data)
    {
    }
    //    public override AddPrice(IResourceManager irm)
    //    {

    //    }
}
