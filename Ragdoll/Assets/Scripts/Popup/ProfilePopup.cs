using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProfilePopup : BasePopup<UserSlot>
{
    public UserSlot container;
    public SoundMusicInProfile soundMusic;

    SoundMusicLanguageStat dataProfile;
    IProfileManager profileManager;
    private void OnValidate()
    {
        if(container == null) container = GetComponentInChildren<UserSlot>();
        if (soundMusic == null) soundMusic = GetComponentInChildren<SoundMusicInProfile>();
    }
    private void Awake()
    {
        profileManager = DIContainer.GetModule<IProfileManager>();
        dataProfile = profileManager.GetDataProfile();
        soundMusic.ShowSoundAndMusic(profileManager);
    }
    public override void SetupData(UserSlot _data = null, List<UserSlot> data = null, string message = null)
    {
        container.IMG_BG.sprite = _data.IMG_BG.sprite;
        container.IMG_ICON.sprite = _data.IMG_ICON.sprite;
        container.NAME.text = _data.NAME.text;
        container.LEVEL.text = "69";
    }
    public void LanguageBtn()
    {
        if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup<SoundMusicLanguageStat>(TypeOfPopup.LanguagePopup, dataProfile);
    }

}
