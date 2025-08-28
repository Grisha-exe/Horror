using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        
        [SerializeField] private ItemsDataList _itemsDataList;
        [SerializeField] private Hotbar _hotbar;
        
        public List<ItemData> CurrentItems = new();
        public List<UISlot> InventorySlots = new ();
        public GameObject ItemDragContainer;
        public Image ItemImage;
        public TMP_Text ItemDescription;
        
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

        public void ShowItemDescription(string itemIndex)
        {
            ItemImage.sprite = _itemsDataList.GetItemDataByIndex(itemIndex).ItemIcon;
            ItemDescription.text = _itemsDataList.GetItemDataByIndex(itemIndex).ItemDescription;
        }
    }
}