using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class AddItemsToHandsController : MonoBehaviour
{
    [SerializeField] private List<PickapableItem> _items;
    [SerializeField] private GameObject ItemHolder;
    [SerializeField] private ItemsDataList _itemsDataList;

    private GameObject _itemInHands;

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

    private void Awake()
    {
        _items = FindObjectsOfType<PickapableItem>().ToList();
    }
}
