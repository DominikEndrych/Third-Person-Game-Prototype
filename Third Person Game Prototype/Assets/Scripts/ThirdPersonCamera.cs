using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Transform _orientation;
    [SerializeField] Transform _player;
    [SerializeField] Transform _playerObj;

    [SerializeField] float _rotationSpeed;

    private void Start()
    {
        HideCrusor();
    }

    private void Update()
    {
        /*
        Vector3 viewDirection = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orientation.forward = viewDirection.normalized;

        // This will be changed for new input system
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        // Change direction of camera
        if(inputDirection != Vector3.zero)
        {
            _playerObj.forward = Vector3.Slerp(_playerObj.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
        */
        
    }

    private void HideCrusor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
