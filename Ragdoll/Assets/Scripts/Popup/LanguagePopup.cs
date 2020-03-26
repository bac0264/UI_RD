using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LanguagePopup : BasePopup<SoundMusicLanguageStat>
{
    public LanguageSlot[] dataBtns;
    SoundMusicLanguageStat _data;
    private void OnValidate()
    {
        if (dataBtns == null || dataBtns.Length == 0) dataBtns = GetComponentsInChildren<LanguageSlot>();
    }
    private void Start()
    {
        Debug.Log(_data);
        for(int i = 0; i < dataBtns.Length; i++)
        {
            dataBtns[i].ID = i;
            dataBtns[i].data = _data;
            dataBtns[i].popup = this;
            dataBtns[i].Language.text = i.ToString();
        }
    }
    public override void SetupData(SoundMusicLanguageStat _data = null, List<SoundMusicLanguageStat> data = null, string message = null)
    {
        this._data = _data;
        Debug.Log(_data);
    }
}