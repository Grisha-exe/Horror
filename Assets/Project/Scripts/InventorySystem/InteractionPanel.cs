using TMPro;
using UnityEngine;

namespace Scripts
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