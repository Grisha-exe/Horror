using Project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class UIController : MonoBehaviour
    {
        public bool IsOpened = true;
        
        [SerializeField] private ItemsDataList _itemDataList;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InteractionPanel _interactionPanel;
        [SerializeField] private GameObject _inventoryOverlay;

        private string _currentItemIndex;
        private PickableItem _currentPickUpPickableItem;
        
        private bool _isPickupWindowOpen = true;


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

        private void Show()
        {
            _inventoryOverlay.SetActive(true);
            IsOpened = true;
        }

        private void Hide()
        {
            _inventoryOverlay.SetActive(false);
            IsOpened = false;
        }


        public void ShowPickupWindow(string index, PickableItem pickableItem)
        {
            if (_isPickupWindowOpen)
                return;

            _isPickupWindowOpen = true;

            _interactionPanel.gameObject.SetActive(true);

            var item = _itemDataList.GetItemDataByIndex(index);

            if (item != null)
            {
                _interactionPanel.SetDataForInteraction(item.ItemName);
                _currentItemIndex = index;
                _currentPickUpPickableItem = pickableItem;
            }
        }

        public void HidePickupWindow()
        {
            if (!_isPickupWindowOpen)
                return;

            _isPickupWindowOpen = false;

            _interactionPanel.gameObject.SetActive(false);
        }

        public void PickUp()
        {
            if (_isPickupWindowOpen)
            {
                if (Inventory.Instance.TryAddItemInInventory(_currentItemIndex))
                {
                    Destroy(_currentPickUpPickableItem.gameObject);
                }
            }
        }
    }
}