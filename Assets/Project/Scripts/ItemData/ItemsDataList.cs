using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "ItemDataList", menuName = "Data/Item")]
    public class ItemsDataList : ScriptableObject
    {
        [SerializeField]private List<ItemData> _items = new();

        public ItemData GetDefaultItem()
        {
            return _items[0];
        }
    
        public ItemData GetItemDataByIndex(string itemIndex)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (itemIndex == _items[i].ItemIndex)
                {
                    return _items[i];
                }
            }

            throw new Exception("Item not found");
        }
    }
}