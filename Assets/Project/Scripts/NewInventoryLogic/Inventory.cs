using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        
        [SerializeField] public ItemsDataList itemsList;
        
        public List<ItemData> CurrentItems = new();
        
        public List<UISlot> slots = new List<UISlot>();


        public void Awake()
        {
            Instance = this;
        }
        
        public void Start()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].Icon.sprite = itemsList.Items[0].ItemIcon;
            }
        }
        
        public bool AddItemInInventory(string index, int count = 1)
        {
            ItemData item = default;
            
            for (int i = 0; i < itemsList.Items.Count; i++)
            {
                if (itemsList.Items[i].ItemIndex == index)
                {
                    item = itemsList.Items[i];
                    CurrentItems.Add(itemsList.Items[i]);
                }
            }
            foreach (var slot in slots)
            {
                if (slot.Item.ItemIndex != "0")
                {
                    slot.Icon.sprite = item.ItemIcon;
                    slot.CountText.text = count.ToString();
                    return true;
                }
            }

            Debug.Log("Inventory is full");
            return false;
        }
        
    }
}