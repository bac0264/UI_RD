using UnityEngine;
using System.Collections;

public class StoryModePanel : BasePanel
{
    public CharacterSlotPanel characterPanel;
    public BoosterSlotPanel boosterPanel;
    ICharacterManager characterManager;
    IResourceManager resourceManager;
    IBoosterManager boosterManager;
    private void Start()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        boosterManager = DIContainer.GetModule<IBoosterManager>();
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
        if (boosterPanel == null) boosterPanel = GetComponentInChildren<BoosterSlotPanel>();
        base.OnValidate();
    }
    public override void HidePanel()
    {
        base.HidePanel();
    }
    public override void HideKey()
    {
        characterPanel.gameObject.SetActive(false);
        base.HideKey();
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
    }
    public override void ShowKey()
    {
        base.ShowKey();
        characterPanel.SetupAll(characterManager, resourceManager);
        characterPanel.gameObject.SetActive(true);
        boosterPanel.SetupAll(boosterManager);
    }
}
