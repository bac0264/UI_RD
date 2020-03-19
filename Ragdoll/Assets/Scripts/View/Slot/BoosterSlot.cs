using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoosterSlot : _ActionSlotSetup<BoosterSlot, BoosterStat>
{
    IBoosterManager boosterManager;
    public Button Buy;
    public Button Free;
    public GameObject IsPick;
    public override BoosterStat DATA
    {
        get => base.DATA; set
        {
            base.DATA = value;

            if (TXT_VALUE != null) TXT_VALUE.text = DATA.VALUE.ToString();
            if (IMG_ICON != null) IMG_ICON.sprite = SpriteDB.Instance.GetIconBoosterInStoryMode(DATA.ID);
            if (IMG_BG != null) IMG_BG.sprite = SpriteDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
            if (DATA.VALUE <= 0) DATA.IsPick = false;
            if (IsPick != null)
            {
                if (DATA.IsPick) IsPick.SetActive(true);
                else IsPick.SetActive(false);
            }
        }
    }
    public void SetupBoosterManager(IBoosterManager boosterManager)
    {
        this.boosterManager = boosterManager;
    }
    private void Start()
    {
        SetupFreeBtn();
        SetupBuyBtn();
    }
    // Pick booster
    #region
    public void PickBooster()
    {
        if (DATA != null && DATA.VALUE > 0)
        {
            if (DATA.IsPick) DATA.IsPick = false;
            else DATA.IsPick = true;
            DATA = DATA;
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
        }
    }
    #endregion
    // Buy Button
    #region
    public void SetupBuyBtn()
    {
        Buy.onClick.RemoveAllListeners();
        Buy.onClick.AddListener(delegate
        {
            BuyBtn();
        });
    }
    public void BuyBtn()
    {
        if (DATA.AddPrice(1))
        {
            DATA = DATA;
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
        }
    }
    #endregion
    // FREE Button
    #region
    public void SetupFreeBtn()
    {
        Free.onClick.RemoveAllListeners();
        Free.onClick.AddListener(delegate
        {
            FreeBtn();
        });
    }
    public void FreeBtn()
    {
        if (DATA.AddPrice(1))
        {
            DATA = DATA;
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
        }
    }
    #endregion
}
