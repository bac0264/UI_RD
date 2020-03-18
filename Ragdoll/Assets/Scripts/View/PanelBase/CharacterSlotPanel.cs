using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSlotPanel : _PanelSetup<CharacterSlot, CharacterStat>
{
    ICharacterManager characterManager;
    IResourceManager resourceManager;
    Snap snap;
    public const int MAX = 100;
    public SO_CharacterUnlock characterData;
    public SO_UpgradeCharacter upgradeCharacterData;

    public GameObject IsUpgrade;
    public GameObject IsUnlock;

    private DataCharacterUnlock dataCharacterUnlock;
    private DataUpgradeCharacter dataUpgradeCharacter;
    private void Awake()
    {
        //SlotListManager.OnRightClick += ShowBooster;
    }

    public void SetupSnap(ICharacterManager characterManager, IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
        this.characterManager = characterManager;
        if (snap == null)
            snap = GetComponentInChildren<Snap>();
        Setup(characterManager.GetCharacterList());
        snap.SetupSnap(characterManager.CurrentCharacter, this, characterManager);
    }

    public void RefeshUI(int _cur)
    {
        int levelMap = 8;
        CharacterStat cur = characterManager.GetCharacterWithID(_cur);
        dataCharacterUnlock = characterData.characterDatas[cur.ID];
        dataUpgradeCharacter = upgradeCharacterData.upgradeCharacterDatas[cur.LEVEL];
        ResourceStat lv = resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.EXP);
        if (!cur.IsBought)
        {
            if (dataCharacterUnlock.IS_GIFT == 0)
            {
                IsUpgrade.SetActive(false);
                IsUnlock.SetActive(false);
            }
            else
            {
                if (levelMap <= (dataCharacterUnlock.LEVEL_UNLOCK - 1))
                {
                    IsUpgrade.SetActive(false);
                    IsUnlock.SetActive(false);
                }
                else
                {
                    IsUpgrade.SetActive(false);
                    IsUnlock.SetActive(true);
                }
            }
        }
        else
        {
            // note lack of transforming exp to level
            if (cur.LEVEL >= MAX)
            {
                IsUpgrade.SetActive(false);
                IsUnlock.SetActive(false);
            }
            else
            {

                IsUpgrade.SetActive(true);
                IsUnlock.SetActive(false);
            }
        }
    }
}
