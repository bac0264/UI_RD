﻿using UnityEngine;
using System.Collections;

public class MapPanel : _PanelSetup<MapSlot, MapDataStat>
{
    public MapEnhance enhance;
    IMapManager mapManager;
    StoryModePanel storyMode;
    private void Start()
    {
        StartCoroutine(SetupEvent());
    }
    private void Awake()
    {
        SlotListManager.OnRightClick += PickLevel;
    } 
    IEnumerator SetupEvent()
    {
        yield return new WaitForSeconds(0.05f);
        SlotListManager.SetupEvent();
        if (SlotListManager is MapSlotList)
        {
            Debug.Log("run");
            MapSlotList slotList = SlotListManager as MapSlotList;
            slotList.SetupMapManager(mapManager);
        }
    }
    public void PickLevel(_ActionSlotSetup<MapSlot, MapDataStat> data)
    {
        if(data.DATA != null && data is MapSlot)
        {
            MapSlot _data = data as MapSlot;
            if(_data != null && _data.PickLevel())
            {
                if (storyMode != null && storyMode.container != null) storyMode.container.PickLevel();
            }
            else
            {

            }
        }
    }
    public void InjectData(IMapManager mapManager, StoryModePanel storyMode)
    {
        this.storyMode = storyMode;
        this.mapManager = mapManager;
        if(SlotListManager is MapSlotList)
        {
            Debug.Log("run");
            MapSlotList slotList = SlotListManager as MapSlotList;
            slotList.SetupMapManager(mapManager);
        }
        Setup(mapManager.MapDataList());
    }
    public override void Setup(MapDataStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public override void HideKey()
    {
        base.HideKey();
    }
    public override void HidePanel()
    {
        base.HidePanel();
    }
    public override void ShowKey()
    {
        base.ShowKey();
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
