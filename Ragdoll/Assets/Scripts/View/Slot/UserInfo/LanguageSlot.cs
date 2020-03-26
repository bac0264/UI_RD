using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class LanguageSlot : MonoBehaviour
{
    public int ID;
    public Button pick;
    public Text Language;
    public SoundMusicLanguageStat data;
    public LanguagePopup popup;
    private void Start()
    {
        pick.onClick.RemoveAllListeners();
        pick.onClick.AddListener(delegate ()
        {
            SetupBtn();
        });
    }
    void SetupBtn()
    {
        data.LANGUAGE = ID;
        popup.HidePopup();
    }
}
