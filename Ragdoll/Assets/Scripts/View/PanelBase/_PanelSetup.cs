using UnityEngine;
using System.Collections;

public class _PanelSetup<T, T1> : BasePanel
{
    public _SlotListSetup<T, T1> SlotListManager;

    public virtual void Setup(T1[] dataBase = null)
    {
        if (SlotListManager == null) SlotListManager = GetComponentInChildren<_SlotListSetup<T, T1>>();
        if (SlotListManager != null) SlotListManager.Setup(dataBase);
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void HidePanel()
    {
        animator.Play("Hide");
    }
    public override void HideKey()
    {
        if (UIMenuManager.Instnace != null) UIMenuManager.Instnace.ShowMenu();
        gameObject.SetActive(false);
    }
    public override void ShowPanel()
    {
        gameObject.SetActive(true);
    }
    public override void ShowKey()
    {

    }
}
