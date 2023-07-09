using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float _speed = 5f;

    [Header("References")]
    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _playerOrientation;
    [SerializeField] Transform _playerObj;
    [SerializeField] Transform _camera;
    [SerializeField] Animator _animator;

    private Vector2 _movementInput;

    private void Update()
    {
        // Compute player orientation based on camera look
        // Player should move and rotate also based on camera movement
        Vector3 viewDirection = transform.position - new Vector3(_camera.position.x, transform.position.y, _camera.position.z);
        _playerOrientation.forward = viewDirection.normalized;

        Move();             // Move player
        ChangeAnimation();  // Walking animation
    }

    // This function is called when player uses controls for moving the character
    // Subscribed to OnMove event
    public void Movement(InputAction.CallbackContext context)
    {
        if(context.performed || context.canceled || context.started)
        {
             _movementInput = context.ReadValue<Vector2>();   // Input from new input system
        }
    }

    // Compute movement based on input values
    private void Move()
    {
        Vector3 direction = _playerOrientation.forward * _movementInput.y + _playerOrientation.right * _movementInput.x;    // Direction where player will move

        // Move player
        if (direction.magnitude >= 0.1f)
        {
            _characterController.Move(direction * _speed * Time.deltaTime);
        }

        // Rotate player model
        if (direction != Vector3.zero)
        {
            _playerObj.forward = Vector3.Slerp(_playerObj.forward, _playerOrientation.forward.normalized, Time.deltaTime * _speed);
        }
    }

    // Change animation based on movement input
    private void ChangeAnimation()
    {
        float dampTime = 0.1f;      // Smoothing the transitions

        _animator.SetFloat("VelocityX", _movementInput.x, dampTime, Time.deltaTime);        // Forward and backward
        _animator.SetFloat("VelocityZ", _movementInput.y, dampTime, Time.deltaTime);        // Left and right
    }
}
