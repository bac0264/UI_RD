using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceShopSlot : ResourceSlot
{
    public Text IAP;
    public Button BuyIAP;
    private void Start()
    {
        SetupBtnIAP();
    }
    public override ResourceStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (DATA is ResourceShopStat)
            {
                ResourceShopStat data = DATA as ResourceShopStat;
                if (IAP != null) IAP.text = data.IAP;
                if (TXT_VALUE != null) TXT_VALUE.text = "+ " + TXT_VALUE.text;
            }
        }
    }
    public override void SetupResourceManager(IResourceManager resourceManager)
    {
        base.SetupResourceManager(resourceManager);
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
        if (resourceManager != null)
        {
            resourceManager.GetResourceWithID(DATA.ID).AddValue(DATA.VALUE);
            resourceManager.SaveResources();
            if (PopupFactory.instance != null)
                PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.ShopPopup, DATA);
        }
    }
}
