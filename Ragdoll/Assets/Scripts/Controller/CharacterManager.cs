using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ICharacterManager
{
    DataSave<CharacterStat> dataSave;
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
    }

    public void SaveCharacters()
    {
    }
}
