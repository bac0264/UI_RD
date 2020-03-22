using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour
{
    public ResourceStat.TypeOfResource type;
    private Text text;
    private void Start()
    {
        if (text == null) text = GetComponent<Text>();
        if (ResourceTextManager.instance != null)
        {
            ResourceTextManager.instance.AddResourceText(this);
        }
    }
    public void UpdateText(IResourceManager resourceManager)
    {
        if (text != null && resourceManager != null)
        {
            text.text = resourceManager.GetResourceWithID((int)type).VALUE.ToString();
        }
    }
}
