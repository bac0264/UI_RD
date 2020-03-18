﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ICharacterManager
{
    IDataService dataService;
    DataSave<CharacterStat> dataSave;
    CharacterStat CurCharacter;
    public CharacterManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadCharacters();
    }

    public CharacterStat CurrentCharacter
    {
        get
        {
            return JsonUtility.FromJson<CharacterStat>(PlayerPrefs.GetString("CurrentCharacter"));
        }
        set
        {
            Debug.Log(value.ID);
            Debug.Log(value.IsBought);
            if (value != null && value.IsBought)
            {
                CurCharacter = value;
                if (CurCharacter != null && CurCharacter.IsBought)
                {
                    Debug.Log("run - 1");
                    PlayerPrefs.SetString("CurrentCharacter", JsonUtility.ToJson(CurCharacter));

                }
            }
        }
    }

    public CharacterStat[] GetCharacterList()
    {
        if (dataSave != null) return dataSave.results.ToArray();
        return null;
    }

    public CharacterStat GetCharacterWithID(int id)
    {
        if (id < dataSave.results.Count) return dataSave.results[id];
        return null;
    }

    public void LoadCharacters()
    {
        dataSave = dataService.GetDataSaveWithType<CharacterStat>();
        if (PlayerPrefs.GetString("CurrentCharacter", "") == "")
        {
            if (dataSave.results.Count > 0)
            {
                dataSave.results[0].IsBought = true;
                CurrentCharacter = dataSave.results[0];
                SaveCharacters();
            }
        }
    }

    public void SaveCharacters()
    {
        dataService.Save<CharacterStat>();
    }
}