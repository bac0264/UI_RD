using UnityEngine;
using System.Collections;
using Spine.Unity;

public class UpgradeHeroPooling : ObjectPooling
{
    public static UpgradeHeroPooling instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override GameObject getObjectPooling(Transform pos = null)
    {
        Debug.Log("run");
        GameObject obj = base.getObjectPooling();
        StartCoroutine(SetDisable(obj));
        return obj;
    }
    IEnumerator SetDisable(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
        obj.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "hero", false);
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
}
