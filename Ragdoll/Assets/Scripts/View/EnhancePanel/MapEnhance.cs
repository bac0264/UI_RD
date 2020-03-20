using UnityEngine;
using System.Collections;
using EnhancedScrollerDemos.NestedScrollers;

public class MapEnhance : Controller
{
    public static MapEnhance instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void Start()
    {
        base.Start();
        masterScroller.ReloadData(masterScroller.NormalizedScrollPosition);
    }
}
