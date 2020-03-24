using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoosterShopSlot : BoosterSlot
{
    public Text AvailableValue;
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
            if (TXT_VALUE != null) TXT_VALUE.text = "+ " + TXT_VALUE.text;
            if (AvailableValue != null)
            {
                if (boosterManager == null) boosterManager = DIContainer.GetModule<IBoosterManager>();
                AvailableValue.text = boosterManager.GetBoosterWithID(DATA.ID).VALUE.ToString();
            }
        }
    }
    public override void SetupBoosterManager(IBoosterManager boosterManager, IResourceManager resourceManager)
    {
        base.SetupBoosterManager(boosterManager, resourceManager);
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
            DATA = DATA;
            if (PopupFactory.instance != null) 
                PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.ShopPopup, DATA);
        }
    }
}
