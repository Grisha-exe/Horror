using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

namespace Scripts.InteractableObjects
{
    public class Drawer : InteractableObject
    {
        public bool IsOpenDrawer;
        public float OpenPositionZ;

        private float _startPositionZ;
        private Transform _currentPosition;

        public void Start()
        {
            _currentPosition = transform;
            _startPositionZ = _currentPosition.localPosition.z;
        }

        public override void Interact()
        {
            if (!IsOpenDrawer)
            {
                IsOpenDrawer = true;    
                _currentPosition.DOLocalMoveZ(OpenPositionZ, 1f);
            }
            else
            {
                IsOpenDrawer = false;
                _currentPosition.DOLocalMoveZ( _startPositionZ, 1f);
            }
        }
    }
}