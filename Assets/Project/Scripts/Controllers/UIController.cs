using UnityEngine;

namespace Scripts
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        
        public bool IsOpened = true;
        
        [SerializeField] private ItemsDataList _itemDataList;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InteractionPanel _interactionPanel;
        [SerializeField] private GameObject _inventoryOverlay;

        private string _currentItemIndex;
        private int _currentItemCount = 1;
        private PickableItem _currentPickUpPickableItem;
        
        private bool _isPickupWindowOpen = true;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            HideInventoryOverlay();
            HidePickupWindow();
        }

        public void SwitchInventoryOverlay()
        {
            if (IsOpened)
            {
                HideInventoryOverlay();
                _cameraController.IsMouseControlEnabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                ShowInventoryOverlay();
                _cameraController.IsMouseControlEnabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            
        }

        private void ShowInventoryOverlay()
        {
            _inventoryOverlay.SetActive(true);
            IsOpened = true;
        }

        private void HideInventoryOverlay()
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

        public void PickUpItem()
        {
            if (_isPickupWindowOpen)
            {
                if (Inventory.Instance.TryAddItemInInventory(_currentItemIndex, _currentItemCount))
                {
                    if (_currentPickUpPickableItem == null)
                    {
                        return;
                    }
                    Destroy(_currentPickUpPickableItem.gameObject);
                    _currentPickUpPickableItem = null;
                    HidePickupWindow();
                }
            }
        }
    }
}