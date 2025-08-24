using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        
        [SerializeField] private ItemsDataList _itemsDataList;
        [SerializeField] private Hotbar _hotbar;
        
        public List<ItemData> CurrentItems = new();
        [FormerlySerializedAs("slots")] public List<UISlot> InventorySlots = new ();
        public GameObject ItemDragContainer;
        
        public void Awake()
        {
            Instance = this;
        }
        
        public void Start()
        {
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                InventorySlots[i].Icon.sprite = _itemsDataList.GetDefaultItem().ItemIcon;
            }
        }
        
        public bool TryAddItemInInventory(string ItemIndex, int itemsCount)
        {
            if (_hotbar.TryAddItemInHotbar(ItemIndex, itemsCount))
            {
                return true;
            }

            var item = _itemsDataList.GetItemDataByIndex(ItemIndex);
            
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                if (InventorySlots[i].Item.ItemIndex == ItemIndex)
                {
                    var newItemsCount = int.Parse(InventorySlots[i].CountText.text) + itemsCount;
                    InventorySlots[i].CountText.text = newItemsCount.ToString();
                    return true;
                }
                
                if (string.IsNullOrEmpty(InventorySlots[i].Item.ItemIndex))
                {
                    InventorySlots[i].Item = item;
                    InventorySlots[i].Icon.sprite = item.ItemIcon;
                    return true;
                }
            }

            Debug.Log("Inventory is full");
            return false;
        }
    }
}