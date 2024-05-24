using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.1f;

    private bool _onGround;
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

    private void FixedUpdate()
    {
        _onGround = Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }

    private void Update()
    {
        float velocityX = _input.Movement.Move.ReadValue<float>();

        _rigidbody.velocity = new Vector2(_speed * velocityX, _rigidbody.velocity.y);
    }

    private void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_onGround)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
