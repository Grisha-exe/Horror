using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        
        [SerializeField] private ItemsDataList _itemsDataList;
        [SerializeField] private Hotbar _hotbar;
        
        public List<ItemData> CurrentItems = new();
        public List<UISlot> slots = new ();
        
        public void Awake()
        {
            Instance = this;
        }
        
        public void Start()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].Icon.sprite = _itemsDataList.GetDefaultItem().ItemIcon;
            }
        }
        
        public bool TryAddItemInInventory(string index, int count = 1)
        {
            if (_hotbar.TryAddItem(index, count))
            {
                return true;
            }

            var item = _itemsDataList.GetItemDataByIndex(index);
            
            for (int i = 0; i < slots.Count; i++)
            {
                if (string.IsNullOrEmpty(slots[i].Item.ItemIndex))
                {
                    slots[i].Item = item;
                    slots[i].Icon.sprite = item.ItemIcon;
                    return true;
                }
            }

            Debug.Log("Inventory is full");
            return false;
        }
    }
}