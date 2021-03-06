﻿using UnityEngine;
using System.Collections;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager Instnace;
    public GameObject Prevent;
    public Animator animator;
    public bool IsHide;
    private void Awake()
    {
        if (Instnace == null) Instnace = this;
    }
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    public void HideMenu()
    {
        Prevent.SetActive(true);
        animator.Play("HideMenu");
    }
    public void HideMenuKey()
    {
        IsHide = true;
    }
    public void ShowMenu()
    {
        animator.Play("ShowMenu");
    }
    public void ShowMenuKey()
    {
        IsHide = false;
        Prevent.SetActive(false);
    }
    // Online Mode
    #region
    public void _OnlineMode()
    {
        StartCoroutine(OnlineMode());
    }
    IEnumerator OnlineMode()
    {
        HideMenu();
        yield return new WaitUntil(() => IsHide);
        if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel(PanelType.OnlineModePanel);
    }
    #endregion
    // Endless Mode
    #region
    public void _EndlessMode()
    {
        StartCoroutine(EndlessMode());
    }
    IEnumerator EndlessMode()
    {
        HideMenu();
        yield return new WaitUntil(() => IsHide);
        if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel(PanelType.EndlessModePanel);
    }
    #endregion
    // Story Mode
    #region
    public void _StoryMode()
    {
        StartCoroutine(StoryMode());
    }
    IEnumerator StoryMode()
    {
        HideMenu();
        yield return new WaitUntil(() => IsHide);
        if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel(PanelType.StoryModePanel);
    }
    #endregion
    // Shop
    #region
    public void _Shop()
    {
        StartCoroutine(Shop());
    }

    IEnumerator Shop()
    {
        HideMenu();
        yield return new WaitUntil(() => IsHide);
        if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel(PanelType.ShopPanel);
    }
    #endregion
    // Daily Gift
    #region
    public void _DailyGift()
    {

    }
    #endregion
    // SPIN
    #region
    public void _Spin()
    {
        StartCoroutine(Spin());
    }
    IEnumerator Spin()
    {
        yield return null;
        HideMenu();
        yield return new WaitUntil(() => IsHide);
        if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel(PanelType.SpinPanel);
    }
    #endregion
}
