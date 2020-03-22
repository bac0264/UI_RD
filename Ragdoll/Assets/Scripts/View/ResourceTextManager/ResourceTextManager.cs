using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceTextManager : MonoBehaviour
{
    public static ResourceTextManager instance;
    List<ResourceText> resourceTextList;
    IResourceManager resourceManager;
    private void Awake()
    {
        resourceTextList = new List<ResourceText>();
        if (instance == null) instance = this;
    }
    public void Start()
    {
        resourceManager = DIContainer.GetModule<IResourceManager>();
    }
    public void AddResourceText(ResourceText rsText)
    {
        if (resourceManager == null)
            resourceManager = DIContainer.GetModule<IResourceManager>();
        resourceTextList.Add(rsText);
        rsText.UpdateText(resourceManager);
    }
    // Use this for initialization
    public void UpdateAllText()
    {
        for (int i = 0; i < resourceTextList.Count; i++)
        {
            if (resourceTextList[i] != null) resourceTextList[i].UpdateText(resourceManager);
        }
    }
}
