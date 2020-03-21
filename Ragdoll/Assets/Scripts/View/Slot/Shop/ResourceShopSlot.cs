using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceShopSlot : ResourceSlot
{
    public Button BuyIAP;
    private void Start()
    {
        
    }
    public override ResourceStat DATA {
        get => base.DATA;
        set => base.DATA = value;
    }

    public override void Setup(IResourceManager resourceManager)
    {
        base.Setup(resourceManager);
    }
    void SetupBtnIAP()
    {
        BuyIAP.onClick.RemoveAllListeners();
        BuyIAP.onClick.AddListener(delegate
        {
            Recieve();
        });
    }
    public void Recieve()
    {
        resourceManager.GetResourceWithID(DATA.ID).AddValue(DATA.VALUE);
        resourceManager.SaveResources();
    }
}
