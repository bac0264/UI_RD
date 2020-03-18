using UnityEngine;
using System.Collections;

public class StoryModePanel : BasePanel
{
    public CharacterSlotPanel characterPanel;

    ICharacterManager characterManager;
    IResourceManager resourceManager;
    IBoosterManager boosterManager;
    private void Start()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        Debug.Log("init");
        boosterManager = DIContainer.GetModule<IBoosterManager>();
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
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
        characterPanel.SetupSnap(characterManager, resourceManager);
        characterPanel.gameObject.SetActive(true);
    }
}
