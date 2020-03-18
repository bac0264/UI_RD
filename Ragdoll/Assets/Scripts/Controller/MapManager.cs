using UnityEngine;
using System.Collections;

public class MapManager : IMapManager
{
    public int HIGHEST_LEVEL { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int CUR_LEVEL { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
[System.Serializable]
public class MapData
{
    public int ID;
    public int STAR;
    public bool IS_PASS;
}