using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float SprintMoveSpeed;

    [SerializeField] private float _currentMoveSpeed;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _currentMoveSpeed = MoveSpeed;
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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
