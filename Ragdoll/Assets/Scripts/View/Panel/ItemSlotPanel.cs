using UnityEngine;
using System.Collections;

public class ItemSlotPanel : _PanelSetup<ItemSlot, ItemStat>
{
    IItemManager itemManager;
    private void Start()
    {
        itemManager = DIContainer.GetModule<IItemManager>();
        Setup(itemManager.GetItemList());
    }
    private void Awake()
    {
        SlotListManager.OnRightClick += ShowItem;
    }
    public override void OnValidate()
    {
        base.OnValidate();
    }
    public override void Setup(ItemStat[] dataBase = null)
    {
        base.Setup(dataBase);
    }
    public void ShowItem(_ActionSlotSetup<ItemSlot, ItemStat> item)
    {
    }
}
