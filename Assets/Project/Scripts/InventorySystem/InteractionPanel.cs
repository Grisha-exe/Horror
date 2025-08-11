using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InteractionPanel : MonoBehaviour

    {
        [SerializeField] private TMP_Text _itemName;

        public void SetDataForInteraction(string itemName)
        {
            _itemName.text = itemName;
        }
    }
}