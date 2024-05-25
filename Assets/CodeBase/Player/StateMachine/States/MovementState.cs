using UnityEngine;

public class MovementState : IState
{
    private PlayerController _playerController;
    private IStateSwitcher _stateSwitcher;

    public MovementState(PlayerController playerController, IStateSwitcher stateSwitcher)
    {
        _playerController = playerController;
        _stateSwitcher = stateSwitcher;
    }

    public void Enter()
    {
        Debug.Log("Movement Enter");
        _playerController.Input.Movement.Jump.started += OnJumpStarted;
        _playerController.Animator.StartMove();
    }

    public void Exit()
    {
        Debug.Log("Movement Exit");
        _playerController.Input.Movement.Jump.started -= OnJumpStarted;
        _playerController.Animator.StopMove();
    }

    public void Update()
    {
        if (_playerController.GetHorizontalInput() == 0)
            _stateSwitcher.SwitchState<IdleState>();

        _playerController.Rigidbody.velocity = new Vector2
        {
            x = _playerController.GetHorizontalInput() * _playerController.StatsConfig.GroundSpeed,
            y = _playerController.Rigidbody.velocity.y
        };
    }

    private void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _stateSwitcher.SwitchState<JumpState>();
    }
}
