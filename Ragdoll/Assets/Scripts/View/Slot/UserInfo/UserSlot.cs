using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserSlot : _ActionSlotSetup<UserSlot, UserStat>
{
    public Image FILL;
    public Image AVATAR;
    public Text LEVEL;
    public Text NAME;
    IUserManager userManager;
    public override UserStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (LEVEL != null) LEVEL.text = "Level 69";
            if (NAME != null) NAME.text = DATA.NAME;
            if(FILL != null)
            {

            }
            if(AVATAR != null)
            {

            }
        }
    }
    public void SetupUserManager(IUserManager userManager)
    {
        this.userManager = userManager;
    }
    public void ShowProfile()
    {
        if(PopupFactory.instance != null)
        {
            PopupFactory.instance.ShowPopup<UserSlot>(TypeOfPopup.ProfilePopup, this);
        }
    }
}
