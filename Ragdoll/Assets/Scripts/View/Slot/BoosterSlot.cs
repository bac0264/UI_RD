using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoosterSlot : _ActionSlotSetup<BoosterSlot, BoosterStat>
{
    IBoosterManager boosterManager;
    public Button Buy;
    public Button Free;
    public override BoosterStat DATA { 
        get => base.DATA; set
        {
            base.DATA = value;

            TXT_VALUE.text = DATA.VALUE.ToString();
            IMG_ICON.sprite = BaseStatDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            IMG_BG.sprite = BaseStatDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
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
    public void SetupBuyBtn()
    {
        Buy.onClick.RemoveAllListeners();
        Buy.onClick.AddListener(delegate
        {
            BuyBtn();
        });
    }
    public void SetupFreeBtn()
    {
        Free.onClick.RemoveAllListeners();
        Free.onClick.AddListener(delegate
        {
            FreeBtn();
        });
    }
    public void BuyBtn()
    {
        if (DATA.AddPrice(1))
        {
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
        }
    }
    public void FreeBtn()
    {
        if (DATA.AddPrice(1))
        {
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
