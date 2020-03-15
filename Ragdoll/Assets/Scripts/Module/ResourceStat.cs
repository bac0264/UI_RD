using UnityEngine;
using System.Collections;
[System.Serializable]
public class ResourceStat : BaseStat
{
    public enum TypeOfResource
    {
        GOLD,
        GEM,
    }
    public ResourceStat(long value, TypeOfResource typeOfResource) : base(value)
    {
        this.ID =(int) typeOfResource;
        NAME = "ResourceStat";
        this.TYPE = (int)Type.Resource;
    }

    //    public override AddPrice(IResourceManager irm)
    //    {

    //    }
}
