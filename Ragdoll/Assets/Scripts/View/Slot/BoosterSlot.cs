﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoosterSlot : _ActionSlotSetup<BoosterSlot, BoosterStat>
{
    public IBoosterManager boosterManager;
    public IResourceManager resourceManager;
    public Button Buy;
    public Button Free;
    public GameObject IsPick;
    public Image ValueImage;
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
            if(ValueImage != null) ValueImage.sprite = SpriteDB.Instance.GetValueImageInBooster(DATA.ID);
        }
    }
    public virtual void SetupBoosterManager(IBoosterManager boosterManager, IResourceManager resourceManager = null)
    {
        this.boosterManager = boosterManager;
        this.resourceManager = resourceManager;
    }
    private void Start()
    {
        SetupFreeBtn();
        SetupBuyBtn();
    }
    // Pick booster
    #region
    public virtual void PickBooster()
    {
        //.Log("run");
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
    void SetupBuyBtn()
    {
        Buy.onClick.RemoveAllListeners();
        Buy.onClick.AddListener(delegate
        {
            BuyBtn();
        });
    }
    void BuyBtn()
    {
        if (resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.GOLD).ReduceValue(500))
        {
            if (DATA.AddValue(1))
            {
                DATA = DATA;
                BoosterStat data = new BoosterStat(1, (BoosterStat.TypeOfBooster)DATA.ID);
                if (boosterManager != null)
                    boosterManager.SaveBoosters();
                else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
                if (resourceManager != null) resourceManager.SaveResources();
                else DIContainer.GetModule<IResourceManager>().SaveResources();
                if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.StoryPopup, data);
            }
            else
            {
                if (NotEnoughGoldPooling.instance != null) NotEnoughGoldPooling.instance.getObjectPooling(Buy.transform);
            }
        }
        else
        {
            if (NotEnoughGoldPooling.instance != null) NotEnoughGoldPooling.instance.getObjectPooling(Buy.transform);
        }
    }
    #endregion
    // FREE Button
    #region
    void SetupFreeBtn()
    {
        Free.onClick.RemoveAllListeners();
        Free.onClick.AddListener(delegate
        {
            if (IronSourceManager.instance != null) IronSourceManager.instance.ShowRewardedVideo(1);
        });
    }
    public void FreeBtn()
    {
        if (DATA.AddValue(1))
        {
            DATA = DATA;
            if (boosterManager != null)
                boosterManager.SaveBoosters();
            else DIContainer.GetModule<IBoosterManager>().SaveBoosters();
            BoosterStat data = new BoosterStat(1, (BoosterStat.TypeOfBooster)DATA.ID);
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup<BaseStat>(TypeOfPopup.StoryPopup, data);
        }
    }
    #endregion
}

