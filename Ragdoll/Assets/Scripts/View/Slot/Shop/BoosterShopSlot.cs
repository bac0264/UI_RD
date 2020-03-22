using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoosterShopSlot : BoosterSlot
{
    public Text IAP;
    public Button BuyIAP;
    private void Start()
    {
        SetupBtnIAP();
    }
    public override BoosterStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (DATA is BoosterShopStat)
            {
                BoosterShopStat data = DATA as BoosterShopStat;
                if (IAP != null) IAP.text = data.IAP;
            }
        }
    }
    public override void SetupBoosterManager(IBoosterManager boosterManager)
    {
        base.SetupBoosterManager(boosterManager);
    }
    void SetupBtnIAP()
    {
        BuyIAP.onClick.RemoveAllListeners();
        BuyIAP.onClick.AddListener(delegate
        {
            Recieve();
        });
    }
    public void Recieve()
    {
        if (boosterManager != null && DATA != null)
        {
            boosterManager.GetBoosterWithID(DATA.ID).AddValue(DATA.VALUE);
            boosterManager.SaveBoosters();
            if (PopupFactory.instance != null) 
                PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.ShopPopup, DATA);
        }
    }
}
