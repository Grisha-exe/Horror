using System;
using System.Collections.Generic;
using Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "Data/Item")]

public class ItemsDataList : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    public ItemData GetItemDataById(string id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (id == items[i].ItemIndex)
            {
                return items[i];
            }
        }

        throw new Exception("Item not found");
    }
}