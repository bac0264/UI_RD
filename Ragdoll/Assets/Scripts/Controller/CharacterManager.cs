using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ICharacterManager
{
    IDataService dataService;
    DataSave<CharacterStat> dataSave;

    public CharacterManager(IDataService dataService)
    {
        this.dataService = dataService;
        LoadCharacters();
    }
    public CharacterStat[] GetCharacterList()
    {
        return null;
    }

    public CharacterStat GetCharacterWithID(int id)
    {
        return null;
    }

    public void LoadCharacters()
    {
        dataSave = dataService.GetDataSaveWithType<CharacterStat>();
    }

    public void SaveCharacters()
    {
        dataService.Save<CharacterStat>();
    }
}
