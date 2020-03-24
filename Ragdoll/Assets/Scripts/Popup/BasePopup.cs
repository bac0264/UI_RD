using UnityEngine;
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
    public Animator animator;
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePopup()
    {
        animator.Play("HidePopup");
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public TypeOfPopup type;
}