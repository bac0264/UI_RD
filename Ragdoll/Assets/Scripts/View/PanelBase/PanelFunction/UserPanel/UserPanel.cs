using UnityEngine;
using System.Collections;

public class UserPanel : MonoBehaviour
{
    IUserManager userManager;


    public UserSlot userSlot;

    private void Awake()
    {
        
    }
    private void Start()
    {
        InjectData();
    }
    // khi nao DI duoc setup o scene khac se day cac phan xu ly len Awake
    public void InjectData()
    {
        userManager = DIContainer.GetModule<IUserManager>();
        userSlot.DATA = userManager.GetUserInfo();
        userSlot.OnRightClickEvent += ClickAvatar;     
    }
    void ClickAvatar(_ActionSlotSetup<UserSlot,UserStat> userSlot)
    {
        if(userSlot is UserSlot)
        {
            UserSlot slot = userSlot as UserSlot;
            slot.ShowProfile();
        }
    }
    public void OnValidate()
    {
        if (userSlot == null) userSlot = GetComponentInChildren<UserSlot>();
    }
}
