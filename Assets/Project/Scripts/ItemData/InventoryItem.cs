using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class InventoryItem : MonoBehaviour
    {
        public string ItemIndex;
        public string ItemName;
        public string ItemDescription;
        public Image ItemIcon;
        public TMP_Text ItemCount;

        public void SetData(ItemData itemData)
        {
            ItemIndex = itemData.ItemIndex;
            ItemName = itemData.ItemName;
            ItemDescription = itemData.ItemDescription;
            ItemIcon.sprite = itemData.ItemIcon;
            ItemCount.text = itemData.ItemCount.ToString();
        }
    }
}