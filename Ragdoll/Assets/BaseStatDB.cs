using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseStatDB : MonoBehaviour
{
    public static BaseStatDB Instance;
    public List<IconList> spriteList;
    public List<BackgroundList> backgroundList;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public Sprite GetIcon(int TYPE, int ID)
    {
        if (TYPE >= spriteList.Count) return null;
        if (ID >= spriteList[TYPE].sprites.Count) return null;
        return spriteList[TYPE].sprites[ID];
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