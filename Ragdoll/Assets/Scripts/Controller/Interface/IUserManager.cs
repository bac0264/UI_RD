using UnityEngine;
using System.Collections;

public interface IUserManager
{
    UserStat GetUserInfo();

    void Save();
    void Load();
}
