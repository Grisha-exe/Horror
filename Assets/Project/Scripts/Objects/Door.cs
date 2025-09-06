    using DG.Tweening;
    using Scripts;
    using UnityEngine;

    public class Door : InteractableObject
    {        
        public bool IsOpenDoor;

        public override void Interact()
        {
            if (!IsOpenDoor)
            {
                IsOpenDoor = true;
                transform.DORotate(new Vector3(0, 90, 0), 1f, RotateMode.LocalAxisAdd);
            }
            else
            {
                IsOpenDoor = false;
                transform.DORotate(new Vector3(0, -90, 0), 1f, RotateMode.LocalAxisAdd);
            }
        }
    }