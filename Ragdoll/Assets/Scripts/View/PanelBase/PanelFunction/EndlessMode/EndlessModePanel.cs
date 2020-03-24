using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessModePanel : BasePanel
{

    public CharacterSlotPanel characterPanel;
    public BoosterSlotPanel boosterPanel;

    ICharacterManager characterManager;
    IResourceManager resourceManager;
    IBoosterManager boosterManager;

    private void Awake()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        boosterManager = DIContainer.GetModule<IBoosterManager>();
        SetupData();
        RefreshUI();
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
        if (boosterPanel == null) boosterPanel = GetComponentInChildren<BoosterSlotPanel>();
        base.OnValidate();
    }
    public void SetupData()
    {
        boosterPanel.SetupAll(boosterManager, resourceManager);
        characterPanel.SetupAll(characterManager, resourceManager);
    }
    // Setup Display
    #region
    public void RefreshUI()
    {
        boosterPanel.gameObject.SetActive(true);
        characterPanel.gameObject.SetActive(true);
    }
    #endregion
    public override void HidePanel()
    {
        base.HidePanel();
    }
    public override void HideKey()
    {
        characterPanel.gameObject.SetActive(false);
        boosterPanel.gameObject.SetActive(false);
        base.HideKey();
    }
    public override void ShowPanel()
    {
        if (boosterManager != null && characterManager != null && resourceManager != null)
        {
            SetupData();
            RefreshUI();
        }
        else
        {
        }
        base.ShowPanel();
    }
    public override void ShowKey()
    {
        base.ShowKey();
    }
    public void Fight()
    {
        SceneManager.LoadScene(0);
    }
}
