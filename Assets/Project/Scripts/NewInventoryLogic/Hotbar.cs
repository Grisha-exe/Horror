using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Hotbar : MonoBehaviour
    {
        public static Hotbar Instance;
        [SerializeField] private GameObject _itemHolder;
        [SerializeField] private ItemsDataList _itemsDataList;
        [SerializeField] private List<GameObject> _slotsBorders = new();
        [SerializeField] private Color _activeItemColor = Color.green;
        [SerializeField] private List<UISlot> _hotbarSlots = new();
        [SerializeField] private InventoryItem _inventoryItem;

        public int ActiveSlotIndex = 0;
        
        private GameObject _currentItemInHands;
        private Color _inactiveItemColor = Color.clear;

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < _slotsBorders.Count; i++)
            {
                _slotsBorders[i].GetComponent<Image>().color = _inactiveItemColor;
                _slotsBorders[ActiveSlotIndex].GetComponent<Image>().color = _activeItemColor;
            }
        }

        public bool TryAddItemInHotbar(string itemIndex, int itemsCount)
        {
            var addableItem = _itemsDataList.GetItemDataByIndex(itemIndex);

            for (int i = 0; i < _hotbarSlots.Count; i++)
            {
                if (_hotbarSlots[i].InventoryItem != null && _hotbarSlots[i].InventoryItem.ItemIndex == itemIndex)
                {
                    var newItemsCount = int.Parse(_hotbarSlots[i].InventoryItem.ItemCount.text) + itemsCount;
                    _hotbarSlots[i].InventoryItem.ItemCount.text = newItemsCount.ToString();
                    return true;
                }

                if (_hotbarSlots[i].InventoryItem == null)
                {
                    var itemSlot = Instantiate(_inventoryItem, _hotbarSlots[i].transform);
                    itemSlot.GetComponent<RectTransform>()
                        .SetParent(_hotbarSlots[i].GetComponent<RectTransform>(), false);
                    itemSlot.GetComponent<RectTransform>().position =
                        _hotbarSlots[i].GetComponent<RectTransform>().position;

                    itemSlot.SetData(addableItem);
                    itemSlot.SetUiSlot(_hotbarSlots[i]);
                    _hotbarSlots[i].InventoryItem = itemSlot;

                    if (i == ActiveSlotIndex)
                    {
                        AddItemToHands(itemIndex);
                    }
                    
                    return true;
                }
            }

            return false;
        }

        public void ClearUISlot(UISlot uiSlot)
        {
            for (int i = 0; i < _hotbarSlots.Count; i++)
            {
                if (_hotbarSlots[i] == uiSlot)
                {
                    _hotbarSlots[i].InventoryItem = null;
                    _hotbarSlots[i].Item = null;
                }

                if (i == ActiveSlotIndex)
                {
                    AddItemToHands(_itemsDataList.GetDefaultItem().ItemIndex);
                }
            }
        }

        public void AddItemToHands(string itemIndex)
        {
            if (string.IsNullOrEmpty(itemIndex))
            {
                Destroy(_currentItemInHands);
                return;
            }

            if (_currentItemInHands == null)
            {
                Destroy(_currentItemInHands);
            }

            var itemToTakeInHands = _itemsDataList.GetItemDataByIndex(itemIndex);

            _currentItemInHands = Instantiate(itemToTakeInHands.ItemModelPrefab, _itemHolder.transform);
            _currentItemInHands.transform.rotation = _itemHolder.transform.rotation;
        }

        public void SetActiveSlot(int hotbarSlotIndex)
        {
            if (hotbarSlotIndex < 0 || hotbarSlotIndex >= _hotbarSlots.Count || hotbarSlotIndex == ActiveSlotIndex)
            {
                return;
            }

            ActiveSlotIndex = hotbarSlotIndex;

            for (int i = 0; i < _slotsBorders.Count; i++)
            {
                _slotsBorders[i].GetComponent<Image>().color = _inactiveItemColor;
            }

            _slotsBorders[hotbarSlotIndex].GetComponent<Image>().color = _activeItemColor;
            
            _hotbarSlots[hotbarSlotIndex].IsActive = true;
            
            if (_hotbarSlots[hotbarSlotIndex].InventoryItem != null)
            {
                AddItemToHands(_hotbarSlots[hotbarSlotIndex].InventoryItem.ItemIndex);
            }
            else
            {
                AddItemToHands(_itemsDataList.GetDefaultItem().ItemIndex);
            }
        }
    }
}