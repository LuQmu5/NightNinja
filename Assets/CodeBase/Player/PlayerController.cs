using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.1f;
    [SerializeField] private LayerMask _groundMask;

    private PlayerAnimator _animator;
    private PlayerStateMachine _stateMachine;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private PlayerStatsConfig _statsConfig;

    public PlayerInput Input => _input;
    public Rigidbody2D Rigidbody => _rigidbody;
    public PlayerStatsConfig StatsConfig => _statsConfig;
    public PlayerAnimator Animator => _animator;

    [Inject]
    public void Construct(PlayerInput input, PlayerStatsConfig playerStatsConfig)
    {
        _animator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _input = input;
        _statsConfig = playerStatsConfig;

        _stateMachine = new PlayerStateMachine(this);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _stateMachine.Update();

        if (GetHorizontalInput() > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (GetHorizontalInput() < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public float GetHorizontalInput() => _input.Movement.Move.ReadValue<float>();
    public bool OnGround() => Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
}
