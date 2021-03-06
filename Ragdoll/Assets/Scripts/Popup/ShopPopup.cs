﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;

public class ShopPopup : BasePopup<BaseStat>
{
    public BaseSlotList baseSlotList;
    public SkeletonAnimation effect;
    public GameObject container;
    bool allowHiding = false;
    private void OnValidate()
    {
        if (baseSlotList == null) baseSlotList = GetComponentInChildren<BaseSlotList>();
    }

    public override void SetupData(BaseStat _data, List<BaseStat> data = null, string message = null)
    {
        if (_data == null && data != null) baseSlotList.Setup(data.ToArray());
        else if (_data != null && data == null)
        {
            data = new List<BaseStat>();
            data.Add(_data);
            baseSlotList.Setup(data.ToArray());
        }
    }
    public override void ShowPopup()
    {
        container.SetActive(false);
        allowHiding = false;
        base.ShowPopup();
    }
    public override void ShowKey()
    {
        StartCoroutine(showEffect());
    }
    IEnumerator showEffect()
    {
        effect.gameObject.SetActive(true);
        effect.AnimationState.SetAnimation(0, "poster", false);
        yield return new WaitForSeconds(0.4f);
        container.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        allowHiding = true;
        effect.gameObject.SetActive(false);
    }
    public override void HidePopup()
    {
        if (allowHiding)
            base.HidePopup();
    }
}
