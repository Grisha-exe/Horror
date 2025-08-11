using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class UISlot : MonoBehaviour
    {
        public ItemData Item;
        public Image Icon;
        public TMP_Text CountText;
        
        
        
        /*public void SetSlot(Item item, int count)
        {
            if (item != null)
            {
                Icon.sprite = item.Icon;
                Icon.enabled = true;
                CountText.text = count > 1 ? count.ToString() : "";
            }
            else
            {
                Icon.sprite = null;
                Icon.enabled = false;
                CountText.text = "";
            }
        }*/
    }
}