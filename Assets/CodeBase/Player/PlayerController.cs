using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerStateMachine _stateMachine;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    public PlayerInput Input => _input;
    public Rigidbody2D Rigidbody => _rigidbody;

    [Inject]
    public void Construct(PlayerInput input, PlayerStatsConfig playerStatsConfig)
    {
        _stateMachine = new PlayerStateMachine(this, playerStatsConfig);
        _input = input;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _stateMachine.Update();
        Debug.Log(_input.Movement.Move.ReadValue<float>());
    }

    public float GetHorizontalInput() => _input.Movement.Move.ReadValue<float>();
}