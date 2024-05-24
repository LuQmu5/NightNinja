using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    private PlayerInput _input;

    [Inject]
    public void Construct(PlayerInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Movement.Jump.started += OnJumpStarted;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Movement.Jump.started -= OnJumpStarted;
    }

    private void Update()
    {
        float velocityX = _input.Movement.Move.ReadValue<float>();
        _rigidbody.velocity = new Vector2(_speed * velocityX, _rigidbody.velocity.y);
    }

    private void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
