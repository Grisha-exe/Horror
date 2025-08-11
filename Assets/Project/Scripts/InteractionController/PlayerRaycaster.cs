using UnityEngine;

namespace Scripts
{
    public class PlayerRaycaster : MonoBehaviour
    {
        [SerializeField] private float _rayLength = 5f;

        private void Update()
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit hit, _rayLength))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                
                var item = hit.collider.GetComponent<PickableItem>();
                
                if (item != null)
                {
                    UIController.Instance.ShowPickupWindow(item.Index, item);
                }
                else
                {
                    UIController.Instance.HidePickupWindow();
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.blue);
                UIController.Instance.HidePickupWindow();
            }
        }
    }
}