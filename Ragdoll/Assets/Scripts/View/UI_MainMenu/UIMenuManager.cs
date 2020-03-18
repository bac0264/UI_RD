using UnityEngine;
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
    public void _Shop()
    {

    }
    public void _DailyGift()
    {

    }

    public void _Spin()
    {
        StartCoroutine(Spin());
    }
    IEnumerator Spin()
    {
        HideMenu();
        yield return new WaitUntil(() => IsHide);
       // if (PanelFactory.instance != null) PanelFactory.instance.ShowPanel<BaseSlot, BaseStat>(PanelType.SpinPanel);
    }
}
