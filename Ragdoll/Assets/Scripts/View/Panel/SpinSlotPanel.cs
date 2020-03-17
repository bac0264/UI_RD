using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSlotPanel : _PanelSetup<BaseSlot, BaseStat>
{
    public SO_Spin spin;
    public int index;
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
        if (spin.SpinDatas.Count > 0)
        {
            index = Random.Range(0, spin.SpinDatas.Count);
            Setup(spinDatas[index].results.ToArray());
        }
    }

    public override void Setup(BaseStat[] database = null)
    {
        if (spinDatas != null)
        {
            index = Random.Range(0, spin.SpinDatas.Count);
            base.Setup(spinDatas[index].results.ToArray());
        }
    }
    public void SpinBtn()
    {

    }
    public void FreeBtn()
    {

    }
}
