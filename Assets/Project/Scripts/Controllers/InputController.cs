using System;
using Project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class InputController : MonoBehaviour
    {
        [FormerlySerializedAs("_inventoryController")] [SerializeField] private UIController uiController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private CameraController _cameraController;
        private Hotbar _hotBar;

        private void Awake()
        {
            _hotBar = FindObjectOfType<Hotbar>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) uiController.Switch();
            
            if (Input.GetKeyDown(KeyCode.LeftShift)) _playerController.SprintOn();
            
            if (Input.GetKeyUp(KeyCode.LeftShift)) _playerController.SprintOff();
            
            if (Input.GetKeyDown(KeyCode.E)) uiController.PickUp();
            
            if (Input.GetKeyDown(KeyCode.Alpha1)) _hotBar.SetActiveSlot(0);
            
            if (Input.GetKeyDown(KeyCode.Alpha2)) _hotBar.SetActiveSlot(1);
            
            if (Input.GetKeyDown(KeyCode.Alpha3)) _hotBar.SetActiveSlot(2);
            
            if (Input.GetKeyDown(KeyCode.Alpha4)) _hotBar.SetActiveSlot(3);
            
            if (Input.GetKeyDown(KeyCode.Alpha5)) _hotBar.SetActiveSlot(4);
        }
    }
}