using UnityEngine;
using System.Collections;

public class StoryModePanel : BasePanel
{
    public CharacterSlotPanel characterPanel;
    public BoosterSlotPanel boosterPanel;
    public MapPanel mapPanel;
    ICharacterManager characterManager;
    IResourceManager resourceManager;
    IBoosterManager boosterManager;
    IMapManager mapManager;
    private void Awake()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        boosterManager = DIContainer.GetModule<IBoosterManager>();
        mapManager = DIContainer.GetModule<IMapManager>();
        SetupData();
        RefreshUI();
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
        if (boosterPanel == null) boosterPanel = GetComponentInChildren<BoosterSlotPanel>();
        if (mapPanel == null) mapPanel = GetComponentInChildren<MapPanel>();
        base.OnValidate();
    }
    public void SetupData()
    {
        mapPanel.SetupAll(mapManager);
        boosterPanel.SetupAll(boosterManager);
        characterPanel.SetupAll(characterManager, resourceManager);
    }

    public void RefreshUI()
    {
        mapPanel.gameObject.SetActive(false);
        boosterPanel.gameObject.SetActive(true);
        characterPanel.gameObject.SetActive(true);
    }
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
        if (boosterManager != null && characterManager != null && resourceManager != null) RefreshUI();
        base.ShowPanel();
    }
    public override void ShowKey()
    {
        base.ShowKey();
    }
}
