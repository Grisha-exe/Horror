using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Scripts
{
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private GameObject ItemHolder;
        [SerializeField] private ItemsDataList _itemsDataList;
        
        public List<UISlot> HotbarSlots = new List<UISlot>();
        public int activeSlotIndex = 0;
        private GameObject _itemInHands;
        
        private void Awake()
        {
            for (int i = 0; i < Inventory.Instance.borders.Count; i++)
            {
                Inventory.Instance.borders[i].SetActive(false);
            }
        }
        
        public void AddItemToHands(string index)
        {
            Destroy(_itemInHands);

            if (Inventory.Instance.CurrentItems.Count <= int.Parse(index))
            {
                return;
            }
        
            _itemInHands = Instantiate(Inventory.Instance.CurrentItems[int.Parse(index)].ItemModelPrefab, ItemHolder.transform);
            _itemInHands.transform.rotation = ItemHolder.transform.rotation;
        }

        public void SetActiveSlot(int slotIndex)
        {
            if (slotIndex >= 0 && slotIndex < HotbarSlots.Count)
            {
                
                activeSlotIndex = slotIndex;
                Debug.Log("Active slot: " + activeSlotIndex);
                
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