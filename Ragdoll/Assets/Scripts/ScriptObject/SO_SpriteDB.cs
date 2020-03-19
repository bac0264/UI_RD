using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "SO_SpriteDB", menuName = "ScriptObject/SO_SpriteDB", order = 1)]
public class SO_SpriteDB : ScriptableObject
{
    public List<IconList> iconList;
    public List<BackgroundList> backgroundList;
    public List<Sprite> iconBoosterInStoryMode;
    public MapSpriteList mapData;
    public Sprite GetIcon(int TYPE, int ID)
    {
        if (TYPE >= iconList.Count) return null;
        if (ID >= iconList[TYPE].sprites.Count) return null;
        return iconList[TYPE].sprites[ID];
    }
    public Sprite GetBackground(int TYPE, int ID)
    {
        if (TYPE >= backgroundList.Count) return null;
        if (ID >= backgroundList[TYPE].sprites.Count) return null;
        return backgroundList[TYPE].sprites[ID];
    }
    public Sprite GetIconInStoryMode(int ID)
    {
        if (ID >= iconBoosterInStoryMode.Count) return null;
        return iconBoosterInStoryMode[ID];
    }
}
[System.Serializable]
public class IconList
{
    public List<Sprite> sprites;
}
[System.Serializable]
public class BackgroundList
{
    public List<Sprite> sprites;
}
[System.Serializable]
public class MapSpriteList
{
    public Sprite Open;
    public Sprite Hide;
    public Sprite KeyOpen;
    public Sprite KeyHide;

    public Sprite GetKey(int index, int starCount)
    {
        if (index <= starCount - 1) return KeyOpen;
        return KeyHide;
    }
    public Sprite GetBackground(bool IsOpen = false)
    {
        if (IsOpen) return Open;
        return Hide;
    }
}
