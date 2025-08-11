using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class Hotbar : MonoBehaviour
    {
        public List<UISlot> HotbarSlots = new List<UISlot>();
        public int activeSlotIndex = 0;
        private AddItemsToHandsController _addItemsToHandsController;

        private void Awake()
        {
            _addItemsToHandsController = FindObjectOfType<AddItemsToHandsController>();
            
            for (int i = 0; i < Inventory.Instance.borders.Count; i++)
            {
                Inventory.Instance.borders[i].SetActive(false);
            }
        }

        public void SetActiveSlot(int slotIndex)
        {
            if (slotIndex >= 0 && slotIndex < HotbarSlots.Count)
            {
                
                activeSlotIndex = slotIndex;
                Debug.Log("Active slot: " + activeSlotIndex);
                
                _addItemsToHandsController.AddItemToHands(Inventory.Instance.CurrentItems[slotIndex].ItemIndex);

                for (int i = 0; i < Inventory.Instance.borders.Count; i++)
                {
                    Inventory.Instance.borders[i].SetActive(false);
                }
                
                Inventory.Instance.borders[slotIndex].SetActive(true);
            }
        }

        public UISlot GetActiveSlot()
        {
            return HotbarSlots[activeSlotIndex];
        }
    }
}