using UnityEngine;
using System.Collections;

public class ProfileManager : IProfileManager
{
    IDataService dataService;
    SoundMusicLanguageStat data;

    public ProfileManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadProfile();
    }
    public SoundMusicLanguageStat GetDataProfile()
    {
        return data;
    }

    public void LoadProfile()
    {
        data = dataService.GetDataProfile();
    }

    public void SaveProfile()
    {
        dataService.Save<SoundMusicLanguageStat>();
    }
}
