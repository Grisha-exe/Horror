using Project.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private ItemsDataList _itemDataList;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] public InteractionPanel InteractionPanel;

        [FormerlySerializedAs("Canvas")] [SerializeField]
        public GameObject InventoryOverlay;

        private string _currentItemIndex;
        private PickapableItem _currentPickUpPickapableItem;

        public bool IsOpened = true;
        private bool IsPickupWindowOpen = true;

        private void Start()
        {
            Hide();
            HidePickupWindow();
        }

        public void Switch()
        {
            if (IsOpened)
            {
                Hide();
                _cameraController.IsMouseControlEnabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Show();
                _cameraController.IsMouseControlEnabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            
        }

        public void Show()
        {
            InventoryOverlay.SetActive(true);
            IsOpened = true;
        }

        public void Hide()
        {
            InventoryOverlay.SetActive(false);
            IsOpened = false;
        }


        public void ShowPickupWindow(string index, PickapableItem pickapableItem)
        {
            if (IsPickupWindowOpen)
                return;

            IsPickupWindowOpen = true;

            InteractionPanel.gameObject.SetActive(true);

            for (int i = 0; i < _itemDataList.items.Count; i++)
            {
                if (_itemDataList.items[i].ItemIndex == index)
                {
                    InteractionPanel.SetDataForInteraction(_itemDataList.items[i].ItemName);
                    _currentItemIndex = index;
                    _currentPickUpPickapableItem =  pickapableItem;
                }
            }
        }

        public void HidePickupWindow()
        {
            if (!IsPickupWindowOpen)
                return;

            IsPickupWindowOpen = false;

            InteractionPanel.gameObject.SetActive(false);
        }

        public void PickUp()
        {
            if (IsPickupWindowOpen)
            {
                _itemDataList.GetItemDataById(_currentItemIndex);
                Inventory.Instance.AddItemInInventory(_currentItemIndex);
                
                Destroy(_currentPickUpPickapableItem.gameObject);
                
                //addItemsToHandsController.AddItemToHands(_currentItemIndex);
            }
        }
    }
}