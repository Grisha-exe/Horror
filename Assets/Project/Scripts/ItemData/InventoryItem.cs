using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts
{
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public string ItemIndex;
        public string ItemName;
        public string ItemDescription;
        public Image ItemIcon;
        public TMP_Text ItemCount;
        private RectTransform _rectTransform;
        private UISlot _uiSlot;


        public void SetData(ItemData itemData)
        {
            ItemIndex = itemData.ItemIndex;
            ItemName = itemData.ItemName;
            ItemDescription = itemData.ItemDescription;
            ItemIcon.sprite = itemData.ItemIcon;
            ItemCount.text = itemData.ItemCount.ToString();
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetUiSlot(UISlot uiSlot)
        {
            _uiSlot = uiSlot;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_uiSlot != null)
            {
                Hotbar.Instance.ClearUISlot(_uiSlot);
            }

            _rectTransform.SetParent(Inventory.Instance.ItemDragContainer.transform, false);
            transform.SetAsLastSibling();
        }


        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _uiSlot.InventoryItem = this;
            _rectTransform.SetParent(_uiSlot.transform);
            transform.position = _uiSlot.transform.position;
            transform.SetAsLastSibling();

            if (_uiSlot.IsActive)
            {
                Hotbar.Instance.AddItemToHands(_uiSlot.InventoryItem.ItemIndex);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<UISlot>() != null)
            {
                _uiSlot = other.GetComponent<UISlot>();
            }
        }
    }
}