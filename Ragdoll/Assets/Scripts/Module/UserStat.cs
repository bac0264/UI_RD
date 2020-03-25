using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserStat
{
    public long EXP;
    public string NAME;
    public UserStat(long EXP, string NAME)
    {
        this.EXP = EXP;
        this.NAME = NAME;
    }
}
