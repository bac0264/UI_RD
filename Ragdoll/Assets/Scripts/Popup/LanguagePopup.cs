using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LanguagePopup : BasePopup<SoundMusicLanguageStat>
{
    public LanguageSlot[] dataBtns;
    SoundMusicLanguageStat _data;
    private void Awake()
    {
        for(int i = 0; i < dataBtns.Length; i++)
        {
            dataBtns[i].ID = i;
            dataBtns[i].data = _data;
            dataBtns[i].popup = this;
        }
    }
    public override void SetupData(SoundMusicLanguageStat _data = null, List<SoundMusicLanguageStat> data = null, string message = null)
    {
        this._data = _data;
    }
}