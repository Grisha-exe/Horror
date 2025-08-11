using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private GameObject _itemHolder;
        [SerializeField] private ItemsDataList _itemsDataList;
        [SerializeField] private List<GameObject> _slotsBorders = new();
        [SerializeField] private Color _activeItemColor = Color.green;

        [SerializeField] private List<UISlot> _hotbarSlots = new();
        public int activeSlotIndex = 0;
        private GameObject _currentItemInHands;
        private Color _colorInactive = Color.clear;

        private void Awake()
        {
            for (int i = 0; i < _slotsBorders.Count; i++)
            {
                _slotsBorders[i].GetComponent<Image>().color = _colorInactive;
            }
        }

        public void AddItemToHands(string itemIndex)
        {
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
        }


        public UISlot GetActiveSlot()
        {
            return _hotbarSlots[activeSlotIndex];
        }
    }
}