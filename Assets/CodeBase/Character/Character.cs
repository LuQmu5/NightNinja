using System;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.1f;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidbody;
    private CharacterConfig _config;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;

    public Rigidbody2D Rigidbody => _rigidbody;
    public CharacterConfig Config => _config;
    public PlayerInput Input => _input;
    public CharacterView View => _view;
    public bool OnGround => Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    public bool IsAttacking { get; private set; } = false;

    [Inject]
    public void Construct(CharacterConfig config)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _config = config;
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();        
        _stateMachine.HandleInput();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public void StartAttack() => IsAttacking = true;
    public void StopAttack() => IsAttacking = false;
}
