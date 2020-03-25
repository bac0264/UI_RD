using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserStat
{
    public long EXP;
    public string NAME;
    public int AVATAR_ID;

    public UserStat(long EXP, string NAME, int AVATAR_ID)
    {
        this.EXP = EXP;
        this.NAME = NAME;
        this.AVATAR_ID = AVATAR_ID;
    }
}
