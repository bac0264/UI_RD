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
            X3Btn.gameObject.SetActive(true);
            container.DATA = _data;
            container.gameObject.SetActive(false);
        }
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
        yield return new WaitForSeconds(1.5f);
        effect.gameObject.SetActive(false);
    }
    public void X3Price()
    {
        x3 = false;
        int count = 1;
        int i = 0;
        while (i > count)
        {
            Debug.LogError("x2");
            i++;
            container.DATA.AddPrice();
        }
        StartCoroutine(AfterX3());
    }
    IEnumerator AfterX3()
    {
        X3Btn.gameObject.SetActive(false);
        effect.gameObject.SetActive(true);
        effect.AnimationState.SetAnimation(0, "poster", false);
        container.DATA.VALUE *= 3;
        container.DATA = container.DATA;
        container.DATA.VALUE /= 3;
        yield return new WaitForSeconds(0.2f);
        container.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        effect.gameObject.SetActive(false);
    }
}
