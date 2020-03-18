﻿using UnityEngine;
using System.Collections;
public enum PanelType
{
    SpinPanel = 0,
    StoryMode = 1,
}
public class BasePanel : MonoBehaviour
{
    public Animator animator;
    public PanelType panelType;
    public virtual void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    public virtual void HidePanel()
    {
        animator.Play("Hide");
    }
    public virtual void HideKey()
    {
        if (UIMenuManager.Instnace != null) UIMenuManager.Instnace.ShowMenu();
        gameObject.SetActive(false);
    }
    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }
    public virtual void ShowKey()
    {

    }
}