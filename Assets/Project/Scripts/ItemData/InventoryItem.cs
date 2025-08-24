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

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }


        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.SetParent(_uiSlot.transform);
            transform.position = _uiSlot.transform.position;
            transform.SetAsLastSibling();

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<UISlot>() != null)
            {
                _uiSlot = other.GetComponent<UISlot>();
                Debug.Log(_uiSlot.name);
            }
        }
    }
}