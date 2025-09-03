using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    public class InteractionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _description;

        public void SetDataForInteraction(string itemName)
        {
            _description.text = itemName;
        }

        public void OpenInteractionPanel()
        {
            _description.text = "Open";
        }
    }
}