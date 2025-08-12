using UnityEngine;

namespace Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private CameraController _cameraController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) uiController.SwitchInventoryOverlay();
            
            if (Input.GetKeyDown(KeyCode.LeftShift)) _playerController.SprintOn();
            
            if (Input.GetKeyUp(KeyCode.LeftShift)) _playerController.SprintOff();
            
            if (Input.GetKeyDown(KeyCode.E)) uiController.PickUp();
            
            if (Input.GetKeyDown(KeyCode.Alpha1)) Hotbar.Instance.SetActiveSlot(0);
            
            if (Input.GetKeyDown(KeyCode.Alpha2)) Hotbar.Instance.SetActiveSlot(1);
            
            if (Input.GetKeyDown(KeyCode.Alpha3)) Hotbar.Instance.SetActiveSlot(2);
            
            if (Input.GetKeyDown(KeyCode.Alpha4)) Hotbar.Instance.SetActiveSlot(3);
            
            if (Input.GetKeyDown(KeyCode.Alpha5)) Hotbar.Instance.SetActiveSlot(4);
        }
    }
}