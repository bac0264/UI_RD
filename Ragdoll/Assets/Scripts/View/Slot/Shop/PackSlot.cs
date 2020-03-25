using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PackSlot : MonoBehaviour
{
    DataSave<BaseStat> data;
    IShopManager shopManager;

    public Button buy;
    public Text IAP;
    public Image icon;


    private DataPack dataPack;
    public DataPack DATA_PACK
    {
        set
        {
            dataPack = value;
            data = BacJson.FromJson<BaseStat, BoosterStat, ResourceStat, CharacterStat>(dataPack.PACK);
            if (IAP != null)
                IAP.text = dataPack.IAP.ToString();
            if (icon != null)
            {
                icon.sprite = SpriteDB.Instance.GetPackIconInShop(dataPack.ID);
            }
        }
        get
        {
            return dataPack;
        }
    }
    public void SetupShopManager(IShopManager shopManager)
    {
        this.shopManager = shopManager;
    }
    private void Start()
    {
        SetupBuyBtn();
    }
    public void SetupBuyBtn()
    {
        buy.onClick.RemoveAllListeners();
        buy.onClick.AddListener(delegate
        {
            BuyBtn();
        });
    }

    void BuyBtn()
    {
        Recieve();
    }

    public void Recieve()
    {
        for (int i = 0; i < data.results.Count; i++)
        {
            data.results[i].AddPrice();
        }
        DataShop dataShop = new DataShop(DATA_PACK.ID);
        shopManager.AddPackRecieving(dataShop);
        shopManager.SaveShops();
        if (PopupFactory.instance != null)
            PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.ShopPopup, null, data.results);
        if (ShopPanel.instance != null) ShopPanel.instance.CheckShowPacks();
        gameObject.SetActive(false);
    }
}
