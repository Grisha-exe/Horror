    using System.Collections;
    using System.Collections.Generic;
    using Scripts;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class Door : InteractableObject
    {
        public float openAngle = -90f;   
        public float speed = 2f;        
        public bool isOpenDoor = false;

        private Quaternion closedRotation;
        private Quaternion openRotation;

        void Start()
        {
            closedRotation = transform.rotation;
            openRotation = Quaternion.Euler(0, openAngle, 0);
        }

        public override void Interact()
        {
            if (!isOpenDoor)
            {
                StartCoroutine(OpenDoor());
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * speed);
            }
        }

        private IEnumerator OpenDoor()
        {
            float currentState = 0f;
                
            while(currentState < 1f)
            {
                currentState += Time.deltaTime / speed;    
                transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, currentState);
                yield return new WaitForEndOfFrame();
            }
        }
    }