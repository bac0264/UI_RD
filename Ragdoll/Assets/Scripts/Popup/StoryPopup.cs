using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine.UI;

public class StoryPopup : BasePopup<BaseStat>
{
    public BaseSlot container;
    public SkeletonAnimation effect;
    bool allowHiding = false;
    public override void SetupData(BaseStat _data, List<BaseStat> data = null, string message = null)
    {
        if (_data != null)
        {
            container.DATA = _data;
            container.gameObject.SetActive(false);
        }
    }
    public override void ShowPopup()
    {
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
        yield return new WaitForSeconds(0.2f);
        container.gameObject.SetActive(true);
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
