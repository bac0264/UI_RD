﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinSlotPanel : _PanelSetup<BaseSlot, BaseStat>
{
    public Transform SpinImage;

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
    public override void OnValidate()
    {
        base.OnValidate();
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
    IEnumerator _SpinAnimation()
    {
        SpinImage.gameObject.SetActive(true);
        for (int i = 0; i < SlotListManager.slotList.Length; i++)
        {
            SpinImage.position = SlotListManager.slotList[i].transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        for(int i = 0; i < 6; i++)
        {
            Tween flicker = SpinImage.GetComponent<Image>().DOColor(new Color(1, 1, 1, 100f / 255), 0.1f);
            yield return flicker.WaitForCompletion();
            flicker = SpinImage.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 0.1f);
            yield return flicker.WaitForCompletion();
        }
    }
    public void FreeBtn()
    {
        StartCoroutine(_SpinAnimation());
    }
}