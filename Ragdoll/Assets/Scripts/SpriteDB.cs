using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteDB : MonoBehaviour
{
    public static SpriteDB Instance;
    public SO_SpriteDB spriteDB;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public Sprite GetPackIconInShop(int ID)
    {
        return spriteDB.GetIconPack(ID);
    }
    public Sprite GetBackgroundInMap(bool IsOpen = false)
    {
        return spriteDB.mapData.GetBackground(IsOpen);
    }
    public Sprite GetKey(int index, int starCount)
    {
        return spriteDB.mapData.GetKey(index,starCount);
    }
    public Sprite GetIcon(int TYPE, int ID)
    {
        return spriteDB.GetIcon(TYPE,ID);
    }
    public Sprite GetBackground(int TYPE, int ID)
    {
        return spriteDB.GetBackground(TYPE,ID);
    }
    public Sprite GetIconBoosterInStoryMode(int ID)
    {
        return spriteDB.GetIconInStoryMode(ID);
    }
}