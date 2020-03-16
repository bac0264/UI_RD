using UnityEngine;
using System.Collections;

public interface ICharacterManager 
{
    CharacterStat[] GetCharacterList();
    CharacterStat GetCharacterWithID(int id);

    void LoadCharacters();
    void SaveCharacters();
}
