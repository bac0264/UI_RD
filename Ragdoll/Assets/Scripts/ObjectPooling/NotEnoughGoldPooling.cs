using UnityEngine;
using System.Collections;

public class NotEnoughGoldPooling : ObjectPooling
{
    public static NotEnoughGoldPooling instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override GameObject getObjectPooling(Transform pos = null)
    {
        GameObject obj = base.getObjectPooling(pos);
        StartCoroutine(SetDisable(obj));
        return obj;
    }
    IEnumerator SetDisable(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
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
