using System;
using System.Collections.Generic;
using Project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "Data/Item")]

public class ItemsDataList : ScriptableObject
{
    public List<ItemData> Items = new List<ItemData>();

    public ItemData GetItemDataByIndex(string itemIndex)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (itemIndex == Items[i].ItemIndex)
            {
                return Items[i];
            }
        }

        throw new Exception("Item not found");
    }
}