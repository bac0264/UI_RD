using UnityEngine;
using System.Collections;

public enum PanelType
{
    SpinPanel = 0,
}
public class _PanelSetup<T, T1> : MonoBehaviour
{
    public PanelType panelType;
    public Animator animator;
    public _SlotListSetup<T, T1> SlotListManager;

    public virtual void Setup(T1[] dataBase = null)
    {
        if (SlotListManager == null) SlotListManager = GetComponentInChildren<_SlotListSetup<T, T1>>();
        if (animator == null) animator = GetComponent<Animator>();
        if (SlotListManager != null) SlotListManager.Setup(dataBase);
    }
    public virtual void HidePanel()
    {
        animator.Play("Hide");
    }
    internal void HideKey()
    {
        if (UIMenuManager.Instnace != null) UIMenuManager.Instnace.ShowMenu();
        gameObject.SetActive(false);
    }
    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }
}
