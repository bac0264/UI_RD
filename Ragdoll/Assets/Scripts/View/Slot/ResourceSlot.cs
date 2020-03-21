using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ResourceSlot : _ActionSlotSetup<ResourceSlot, ResourceStat>
{
    public IResourceManager resourceManager;

    public virtual void SetupResourceManager(IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
    }
    public override ResourceStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (TXT_VALUE != null)
                TXT_VALUE.text = DATA.VALUE.ToString();
            if (IMG_ICON != null)
                IMG_ICON.sprite = SpriteDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            if (IMG_BG != null)
                IMG_BG.sprite = SpriteDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
        }
    }
}
