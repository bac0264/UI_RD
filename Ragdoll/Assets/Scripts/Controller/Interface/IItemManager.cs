using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IItemManager
{
    ItemStat[] GetItemList();
    ItemStat GetItemWithID(int id);

    void LoadItems();
    void SaveItems();
}