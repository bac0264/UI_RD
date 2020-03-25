using UnityEngine;
using System.Collections;

public interface IProfileManager 
{
    SoundMusicLanguageStat GetDataProfile();

    void SaveProfile();
    void LoadProfile();
}
