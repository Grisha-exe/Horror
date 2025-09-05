using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        
        public bool IsOpenedInventory = true;
        
        [SerializeField] private ItemsDataList _itemDataList;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InteractionPanel _interactionPanel;
        [SerializeField] private GameObject _inventoryOverlay;

        public bool IsInteractWindowOpen = false;
        
        private Door _door;
        private string _currentItemIndex;
        private int _currentItemCount = 1;
        private PickableItem _currentPickableItem;
        
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
            if (IsOpenedInventory)
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
            IsOpenedInventory = true;
        }

        private void HideInventoryOverlay()
        {
            _inventoryOverlay.SetActive(false);
            IsOpenedInventory = false;
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
                _currentPickableItem = pickableItem;
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
                    if (_currentPickableItem == null)
                    {
                        return;
                    }
                    Destroy(_currentPickableItem.gameObject);
                    _currentPickableItem = null;
                    HidePickupWindow();
                }
            }
        }

        public void ShowInterractionWithBox()
        {
            _interactionPanel.gameObject.SetActive(true);
            IsInteractWindowOpen = true;
            _interactionPanel.OpenInteractionPanel();
        }

        public void HideInterractionWithBox()
        {
            _interactionPanel.gameObject.SetActive(false);
            IsInteractWindowOpen = false;
        }

        public void OpenOrCloseBox()
        {
            if (IsInteractWindowOpen)
            {
                
            }
        }
    }
}