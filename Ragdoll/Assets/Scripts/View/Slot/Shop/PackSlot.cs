using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PackSlot : MonoBehaviour
{
    DataSave<BaseStat> data;



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
                icon.sprite = SpriteDB.Instance.GetPackIconInShop(dataPack.ID);
        }
        get
        {
            return dataPack;
        }
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
        if (PopupFactory.instance != null)
            PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.ShopPopup, null, data.results);
    }
}
