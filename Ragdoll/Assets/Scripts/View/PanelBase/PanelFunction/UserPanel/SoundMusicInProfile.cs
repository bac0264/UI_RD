using UnityEngine;
using System.Collections;

public class SoundMusicInProfile : MonoBehaviour
{
    public GameObject OnMusic;
    public GameObject OffMusic;
    public GameObject OnSound;
    public GameObject OffSound;
    private SoundMusicLanguageStat dataProfile;
    private IProfileManager profileManager;
    public void ShowSoundAndMusic(IProfileManager profileManager)
    {
        this.profileManager = profileManager;
        dataProfile = profileManager.GetDataProfile();
        
        if (!dataProfile.SOUND)
        {
            TurnOffSound();
        }
        else
        {
            TurnOnSound();
        }
        if (!dataProfile.MUSIC)
        {
            TurnOffMusic();
        }
        else
        {
            TurnOnMusic();
        }
    }
    public void TurnOffSound()
    {
       // if (SoundManager.instance != null) SoundManager.instance.Click_Sound();
        OffSound.SetActive(true);
        OnSound.SetActive(false);
        dataProfile.SOUND = false;
        if (SoundManager.instance != null) SoundManager.instance.MuteAllSound();
        profileManager.SaveProfile();
    }
    public void TurnOnSound()
    {
       // if (SoundManager.instance != null) SoundManager.instance.Click_Sound();
        OffSound.SetActive(false);
        OnSound.SetActive(true);
        dataProfile.SOUND = true;
        if (SoundManager.instance != null) SoundManager.instance.UnMuteAllSound();
        profileManager.SaveProfile();
    }
    public void TurnOffMusic()
    {
        //if (SoundManager.instance != null) SoundManager.instance.Click_Sound();
        OffMusic.SetActive(true);
        OnMusic.SetActive(false);
        dataProfile.MUSIC = false;
        if (MusicManager.instance != null) MusicManager.instance.MuteAllMusic();
        profileManager.SaveProfile();
    }
    public void TurnOnMusic()
    {
       // if (SoundManager.instance != null) SoundManager.instance.Click_Sound();
        OffMusic.SetActive(false);
        OnMusic.SetActive(true);
        dataProfile.MUSIC = true;
        if (MusicManager.instance != null) MusicManager.instance.UnMuteAllMusic();
        profileManager.SaveProfile();
    }
}