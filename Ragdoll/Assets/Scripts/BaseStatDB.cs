using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseStatDB : MonoBehaviour
{
    public static BaseStatDB Instance;
    public List<IconList> iconList;
    public List<BackgroundList> backgroundList;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
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