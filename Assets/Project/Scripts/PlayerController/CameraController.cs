using UnityEngine;

namespace Scripts
{
    public class CameraController : MonoBehaviour
    {
        private const float Sensitivity = 2.0f;
        private const float MaxAngle = 80.0f;
    
        public bool IsMouseControlEnabled = true;
    
        private float _rotationX = 0.0f;

        void Update()
        {
            if (IsMouseControlEnabled == false)
            {
                return;
            }
        
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up * mouseX * Sensitivity);

            _rotationX -= mouseY * Sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -MaxAngle, MaxAngle);
        
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        }
    }
}