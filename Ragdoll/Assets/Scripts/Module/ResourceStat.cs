using UnityEngine;
using System.Collections;
[System.Serializable]
public class ResourceStat : BaseStat
{
    public enum TypeOfResource
    {
        GOLD = 0,
    }
    public ResourceStat(long value, TypeOfResource typeOfResource) : base(value)
    {
        this.ID =(int) typeOfResource;
        NAME = Type.ResourceStat.ToString();
        this.TYPE = (int)Type.ResourceStat;
    }

    //    public override AddPrice(IResourceManager irm)
    //    {

    //    }
}
