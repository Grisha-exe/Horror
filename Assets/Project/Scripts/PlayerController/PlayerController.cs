using UnityEngine;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float MoveSpeed = 5.0f;
        public float SprintMoveSpeed;

        private float _currentMoveSpeed;
        private CharacterController _controller;

        void Start()
        {
            _currentMoveSpeed = MoveSpeed;
            _controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
        
            Vector3 moveDirection = transform.forward * verticalInput +  transform.right * horizontalInput;
        
            _controller.Move(moveDirection * _currentMoveSpeed * Time.deltaTime);
            _controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
        }

        public void SprintOn()
        {
            _currentMoveSpeed = MoveSpeed + SprintMoveSpeed;
        }

        public void SprintOff()
        {
            _currentMoveSpeed = MoveSpeed;
        }
    }
}
