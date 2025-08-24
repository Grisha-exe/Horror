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

        public int activeSlotIndex = 0;
        private GameObject _currentItemInHands;
        private Color _colorInactive = Color.clear;

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < _slotsBorders.Count; i++)
            {
                _slotsBorders[i].GetComponent<Image>().color = _colorInactive;
            }
        }

        public bool TryAddItemInHotbar(string itemIndex, int itemsCount)
        {
            var item = _itemsDataList.GetItemDataByIndex(itemIndex);

            for (int i = 0; i < _hotbarSlots.Count; i++)
            {
                if (_hotbarSlots[i].InventoryItem != null && _hotbarSlots[i].InventoryItem.ItemIndex == itemIndex)
                {
                    Debug.Log("Same Item found");
                    var newItemsCount = int.Parse(_hotbarSlots[i].InventoryItem.ItemCount.text) + itemsCount;
                    _hotbarSlots[i].InventoryItem.ItemCount.text = newItemsCount.ToString();
                    return true;
                }

                if (_hotbarSlots[i].InventoryItem == null)
                {
                    Debug.Log("New item found");
                    var itemSlot = Instantiate(_inventoryItem, _hotbarSlots[i].transform);
                    itemSlot.GetComponent<RectTransform>().SetParent(_hotbarSlots[i].GetComponent<RectTransform>(), false);
                    itemSlot.GetComponent<RectTransform>().position =
                        _hotbarSlots[i].GetComponent<RectTransform>().position;
                    
                    itemSlot.SetData(item);
                    _hotbarSlots[i].InventoryItem = itemSlot;
                    return true;
                }
            }

            return false;
        }

        private void AddItemToHands(string itemIndex)
        {
            if (string.IsNullOrEmpty(itemIndex))
            {
                Destroy(_currentItemInHands);
                return;
            }

            if (_currentItemInHands != null)
            {
                Destroy(_currentItemInHands);
            }

            var itemToTakeInHands = _itemsDataList.GetItemDataByIndex(itemIndex);

            _currentItemInHands = Instantiate(itemToTakeInHands.ItemModelPrefab, _itemHolder.transform);
            _currentItemInHands.transform.rotation = _itemHolder.transform.rotation;
        }

        public void SetActiveSlot(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= _hotbarSlots.Count || slotIndex == activeSlotIndex)
            {
                return;
            }

            activeSlotIndex = slotIndex;
            Debug.Log("Active slot: " + activeSlotIndex);

            for (int i = 0; i < _slotsBorders.Count; i++)
            {
                _slotsBorders[i].GetComponent<Image>().color = _colorInactive;
            }

            _slotsBorders[slotIndex].GetComponent<Image>().color = _activeItemColor;

            AddItemToHands(_hotbarSlots[slotIndex].Item.ItemIndex);
        }
    }
}