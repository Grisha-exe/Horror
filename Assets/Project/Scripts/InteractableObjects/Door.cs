    using DG.Tweening;
    using Scripts;
    using UnityEngine;

    public class Door : InteractableObject
    {        
        public bool IsOpenDoor;
        public float RotationAngle;
        
        private Quaternion _openedRotationPosition;
        private Quaternion _closedRotationPosition;

        public void Start()
        {
            _openedRotationPosition = transform.rotation;
            _closedRotationPosition = Quaternion.Euler(0, RotationAngle, 0);
        }

        public override void Interact()
        {
            if (!IsOpenDoor)
            {
                IsOpenDoor = true;
                transform.DORotateQuaternion(_closedRotationPosition, 1f);
            }
            else
            {
                transform.DORotateQuaternion(_openedRotationPosition, 1f);
                IsOpenDoor = false;
            }
        }
    }