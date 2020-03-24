using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OnlineModePanel : BasePanel
{

    public CharacterSlotPanel characterPanel;

    ICharacterManager characterManager;
    IResourceManager resourceManager;

    private void Awake()
    {
        characterManager = DIContainer.GetModule<ICharacterManager>();
        resourceManager = DIContainer.GetModule<IResourceManager>();
        SetupData();
        RefreshUI();
    }
    public override void OnValidate()
    {
        if (characterPanel == null) characterPanel = GetComponentInChildren<CharacterSlotPanel>();
        base.OnValidate();
    }
    public void SetupData()
    {
        characterPanel.InjectData(characterManager, resourceManager);
    }
    // Setup Display
    #region
    public void RefreshUI()
    {
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
        base.HideKey();
    }
    public override void ShowPanel()
    {
        if (characterManager != null && resourceManager != null)
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
