    using Scripts;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class Door : MonoBehaviour
    {
        public float openAngle = 90f;   // на сколько градусов откроется
        public float speed = 2f;        // скорость открытия
        public bool isOpenDoor = false;

        private Quaternion closedRotation;
        private Quaternion openRotation;

        void Start()
        {
            closedRotation = transform.rotation;
            openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
        }

        public void SwitchDoor()
        {
            if (!isOpenDoor)
            {
                if (UIController.Instance.IsInteractWindowOpen)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * speed);
                }
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * speed);
            }
        }
    }