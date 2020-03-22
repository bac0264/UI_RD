using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryModePanel : BasePanel
{

    public CharacterSlotPanel characterPanel;
    public BoosterSlotPanel boosterPanel;
    public MapPanel mapPanel;
    public StoryModeAnimation container;

    ICharacterManager characterManager;
    IResourceManager resourceManager;
    IBoosterManager boosterManager;
    IMapManager mapManager;

    public TextMeshPro LevelText;
    string levelText;
    private void Awake()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        boosterManager = DIContainer.GetModule<IBoosterManager>();
        mapManager = DIContainer.GetModule<IMapManager>();
        levelText = LevelText.text;
        SetupData();
        RefreshUI();
        SetLevelText();
        container.SetupStoryMode(this);
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
        if (boosterPanel == null) boosterPanel = GetComponentInChildren<BoosterSlotPanel>();
        if (container == null) container = GetComponentInChildren<StoryModeAnimation>();
        if (mapPanel == null) mapPanel = GetComponentInChildren<MapPanel>();
        base.OnValidate();
    }
    public void SetupData()
    {
        mapPanel.SetupAll(mapManager, this);
        boosterPanel.SetupAll(boosterManager);
        characterPanel.SetupAll(characterManager, resourceManager);
    }
    // Setup Display
    #region
    public void RefreshUI()
    {
        boosterPanel.gameObject.SetActive(true);
        characterPanel.gameObject.SetActive(true);
        mapPanel.gameObject.SetActive(false);
        mapManager.CUR_MAP = mapManager.HIGHEST_MAP;
    }
    public void SetLevelText()
    {
        LevelText.text = levelText + (mapManager.CUR_MAP.ID + 1).ToString();
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
            SetLevelText();
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
