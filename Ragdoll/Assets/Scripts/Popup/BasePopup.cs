﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum TypeOfPopup
{
    ShopPopup,
}
public class BasePopup<T> : BasePopupSimple
{ 
    public override void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public override void HidePopup()
    {
        gameObject.SetActive(false);
    }
    public virtual void SetupData(T _data = default,List<T> data = null, string message = null)
    {

    }
}
public class BasePopupSimple : MonoBehaviour
{
    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePopup()
    {
        gameObject.SetActive(false);
    }
    public TypeOfPopup type;
}