using UnityEngine;
using System.Collections;

public class UserManager : IUserManager
{
    IDataService dataService;
    UserStat userStat;
    public UserManager(IDataService dataService)
    {
        this.dataService = dataService;
        Load();
    }
    public UserStat GetUserInfo()
    {
        return userStat;
    }

    public void Load()
    {
        userStat = dataService.GetUserInfo();
    }

    public void Save()
    {
        dataService.Save<UserStat>();
    }
}
