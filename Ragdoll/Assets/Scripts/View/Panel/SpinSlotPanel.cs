using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSlotPanel : _PanelSetup<BaseSlot,BaseStat>
{
    public SO_Spin spin;
    List<DataSave<BaseStat>> spinDatas;
    private void Start()
    {
        InjectData();
    }
    public void InjectData()
    {
        spinDatas = new List<DataSave<BaseStat>>();
        for (int i = 0; i < spin.SpinDatas.Count; i++)
        {
            DataSave<BaseStat> data = BacJson.FromJson<BaseStat, CharacterStat, ResourceStat>(spin.SpinDatas[i].json);
            spinDatas.Add(data);
        }
        int index = Random.Range(0, spin.SpinDatas.Count);
        Setup(spinDatas[index].results.ToArray());
    }
    public override void Setup(BaseStat[] database)
    {
        base.Setup(database);
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
