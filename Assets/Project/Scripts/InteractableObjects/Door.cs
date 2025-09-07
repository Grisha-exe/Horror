using DG.Tweening;
using Scripts;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private Vector3 _openRotation = new Vector3(0, 90, 0);

    private bool _isOpen = false;

    public override void Interact()
    {
        if (_isOpen)
        {
            transform.DOLocalRotate(Vector3.zero, _duration);
        }
        else
        {
            transform.DOLocalRotate(_openRotation, _duration);
        }

        _isOpen = !_isOpen;
    }
}