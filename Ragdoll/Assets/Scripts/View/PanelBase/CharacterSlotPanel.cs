using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSlotPanel : _PanelSetup<CharacterSlot, CharacterStat>
{
    public const int MAX = 9;
    public const int ATK_MAX = 5300;
    public const int HP_MAX = 12590;
    ICharacterManager characterManager;
    IResourceManager resourceManager;

    public Snap snap;
    public SO_CharacterUnlock characterData;
    public SO_UpgradeCharacter upgradeCharacterData;

    public GameObject IsUpgrade;
    public GameObject IsUnlock;

    public Text Display;
    public Text HP_VALUE;
    public Text ATK_VALUE;
    public Text VIDEO_VALUE;
    public Text GOLD_VALUE;
    public Text GOLD_UPGRADE_VALUE;

    public Image fillATK;
    public Image fillHP;

    private DataCharacterUnlock dataCharacterUnlock;
    private DataUpgradeCharacter dataUpgradeCharacter;
    private CharacterStat currrentCharacter;

    private void Awake()
    {
        //SlotListManager.OnRightClick += ShowBooster;
    }
    public override void OnValidate()
    {
        base.OnValidate();
        if (snap == null)
            snap = GetComponentInChildren<Snap>();
    }

    public void SetupAll(ICharacterManager characterManager, IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
        this.characterManager = characterManager;
        Setup(characterManager.GetCharacterList());
        snap.SetupSnap(characterManager.CurrentCharacter, this, characterManager);
    }

    public void RefeshUI(int _cur)
    {
        int levelMap = 50;
        currrentCharacter = characterManager.GetCharacterWithID(_cur);
        characterManager.CurrentCharacter = currrentCharacter;
        dataCharacterUnlock = characterData.characterDatas[currrentCharacter.ID];
        dataUpgradeCharacter = upgradeCharacterData.upgradeCharacterDatas[currrentCharacter.LEVEL];
        //  ResourceStat lv = resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.EXP);
        if (!currrentCharacter.IsBought)
        {
            if (dataCharacterUnlock.IS_GIFT == 0)
            {
                // Là quà tặng
                IsUpgrade.SetActive(false);
                IsUnlock.SetActive(false);
                Display.text = " Open gift to recieve.";
                Display.gameObject.SetActive(true);
            }
            else
            {
                if (levelMap <= (dataCharacterUnlock.LEVEL_UNLOCK - 1))
                {
                    IsUpgrade.SetActive(false);
                    IsUnlock.SetActive(false);
                    Display.text = " Reach map level " + dataCharacterUnlock.LEVEL_UNLOCK + " to unlock.";
                    Display.gameObject.SetActive(true);
                }
                else
                {
                    IsUpgrade.SetActive(false);
                    IsUnlock.SetActive(true);
                    VIDEO_VALUE.text = (dataCharacterUnlock.VIDEO_UNLOCK - currrentCharacter.VideoUnlock).ToString();
                    GOLD_VALUE.text = dataCharacterUnlock.GOLD_UNLOCK.ToString();
                    Display.gameObject.SetActive(false);
                }
            }
            HP_VALUE.text = dataCharacterUnlock.HP.ToString();
            ATK_VALUE.text = dataCharacterUnlock.ATK.ToString();
        }
        else
        {
            // note lack of transforming exp to level
            if (currrentCharacter.LEVEL >= (MAX + currrentCharacter.ID))
            {
                IsUpgrade.SetActive(false);
                IsUnlock.SetActive(false);
                Display.text = "Reach max level";
                Display.gameObject.SetActive(true);
            }
            else
            {
                IsUpgrade.SetActive(true);
                IsUnlock.SetActive(false);
                Display.gameObject.SetActive(false);
                GOLD_UPGRADE_VALUE.text = dataUpgradeCharacter.GOLD.ToString();
            }
        }
        RefreshHeroStat();
    }
    public void RefreshHeroStat()
    {
        int HPbonus = 0;
        int ATKbonus = 0;
        for (int i = 0; i < upgradeCharacterData.upgradeCharacterDatas.Count && i < currrentCharacter.LEVEL; i++)
        {
            HPbonus += upgradeCharacterData.upgradeCharacterDatas[i].HP;
            ATKbonus += upgradeCharacterData.upgradeCharacterDatas[i].ATK;
        }
        ATKbonus += dataCharacterUnlock.ATK;
        HPbonus += dataCharacterUnlock.HP;
        HP_VALUE.text = HPbonus.ToString();
        ATK_VALUE.text = ATKbonus.ToString();
        fillATK.fillAmount = (float)ATKbonus / ATK_MAX;
        fillHP.fillAmount = (float)HPbonus / HP_MAX;
        characterManager.CurrentCharacter = currrentCharacter;
    }
    public void Upgrade()
    {
        if (currrentCharacter.LEVEL >= (MAX + currrentCharacter.ID)) return;
        //  resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.GOLD).AddValue(dataUpgradeCharacter.GOLD);
        if (resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.GOLD).ReduceValue(dataUpgradeCharacter.GOLD))
        {
            currrentCharacter.LEVEL++;
            characterManager.SaveCharacters();
            resourceManager.SaveResources();
            if (UpgradeHeroPooling.instance != null) UpgradeHeroPooling.instance.getObjectPooling();
        }
        else
        {
            if (NotEnoughGoldPooling.instance != null) NotEnoughGoldPooling.instance.getObjectPooling(GOLD_UPGRADE_VALUE.transform);
        }
    }
    public void Unlock()
    {
        //  resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.GOLD).AddValue(dataCharacterUnlock.GOLD_UNLOCK);
        if (resourceManager.GetResourceWithID((int)ResourceStat.TypeOfResource.GOLD).ReduceValue(dataCharacterUnlock.GOLD_UNLOCK))
        {
            currrentCharacter.IsBought = true;
            characterManager.SaveCharacters();
            resourceManager.SaveResources();
        }
        else
        {
            if (NotEnoughGoldPooling.instance != null) NotEnoughGoldPooling.instance.getObjectPooling(GOLD_VALUE.transform);
        }
    }

    public void VideoUnlock()
    {
        currrentCharacter.VideoUnlock++;
        if (currrentCharacter.VideoUnlock == dataCharacterUnlock.VIDEO_UNLOCK)
            currrentCharacter.IsBought = true;
        characterManager.SaveCharacters();
    }
}
