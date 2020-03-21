using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ResourceSlot : _ActionSlotSetup<ResourceSlot,ResourceStat>
{
    public IResourceManager resourceManager;

    public virtual void Setup(IResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
    }
    public override ResourceStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;

            TXT_VALUE.text = DATA.VALUE.ToString();
            IMG_ICON.sprite = SpriteDB.Instance.GetIcon(DATA.TYPE, DATA.ID);
            IMG_BG.sprite = SpriteDB.Instance.GetBackground(DATA.TYPE, DATA.ID);
        }
    }
}
