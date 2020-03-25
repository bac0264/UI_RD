using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine.UI;

public class SpinPopup : BasePopup<BaseStat>
{
    public BaseSlot container;
    public SkeletonAnimation effect;
    public Button X3Btn;
    public bool x3;
    bool allowHiding = false;
    private void Start()
    {
        X3Btn.onClick.RemoveAllListeners();
        X3Btn.onClick.AddListener(delegate
        {
            X3Price();
        });
    }
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
        X3Btn.gameObject.SetActive(false);
        base.ShowPopup();
    }
    public override void ShowKey()
    {
        StartCoroutine(showEffect());
    }
    IEnumerator showEffect()
    {
        x3 = false;
        effect.gameObject.SetActive(true);
        effect.AnimationState.SetAnimation(0, "poster", false);
        yield return new WaitForSeconds(0.25f);
        container.gameObject.SetActive(true);
        if (container.DATA is CharacterStat)
            X3Btn.gameObject.SetActive(false);
        else X3Btn.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.65f);
        effect.gameObject.SetActive(false);
        x3 = true;
        allowHiding = true;
    }
    public void X3Price()
    {
        if (x3)
        {
            int count = 0;
            int i = 0;
            while (i <= count)
            {
                i++;
                Debug.Log(i);
                container.DATA.AddPrice();
            }
            StartCoroutine(AfterX3());
        }
    }
    IEnumerator AfterX3()
    {
        X3Btn.gameObject.SetActive(false);
        effect.gameObject.SetActive(true);
        effect.AnimationState.SetAnimation(0, "poster", false);
        container.DATA.VALUE *= 3;
        yield return new WaitForSeconds(0.5f);
        container.DATA = container.DATA;
        container.DATA.VALUE /= 3;
        if (ResourceTextManager.instance != null) ResourceTextManager.instance.UpdateAllText();
        yield return new WaitForSeconds(0.5f);
        effect.gameObject.SetActive(false);
    }
    public override void HidePopup()
    {
        if (allowHiding)
        {
            if (ResourceTextManager.instance != null) ResourceTextManager.instance.UpdateAllText();
            base.HidePopup();
        }
    }
}
