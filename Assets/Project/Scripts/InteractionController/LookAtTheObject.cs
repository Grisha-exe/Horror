using System;
using InventorySystem;
using UnityEngine;

namespace Project.Scripts.InteractionController
{
    public class LookAtTheObject : MonoBehaviour
    {
        [SerializeField] private float _rayLength = 5f;
        [SerializeField] private UIController uiController;

        private void Start()
        {
            uiController = FindObjectOfType<UIController>();
        }

        private void Update()
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit hit, _rayLength))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                
                if (hit.collider.GetComponent<PickableItem>() != null)
                {
                    var index = hit.collider.GetComponent<PickableItem>().Index;
                    uiController.ShowPickupWindow(index, hit.collider.GetComponent<PickableItem>());
                }
                else
                {
                    uiController.HidePickupWindow();
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.blue);
                uiController.HidePickupWindow();
            }
        }
    }
}