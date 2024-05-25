using UnityEngine;

public class IdleState : IState
{
    private PlayerController _playerController;
    private IStateSwitcher _stateSwitcher;

    public IdleState(PlayerController playerController, IStateSwitcher stateSwitcher)
    {
        _playerController = playerController;
        _stateSwitcher = stateSwitcher;
    }

    public void Enter()
    {
        Debug.Log("Idle Enter");
        _playerController.Input.Movement.Jump.started += OnJumpStarted;
        _playerController.Animator.StartIdle();
    }

    public void Exit()
    {
        Debug.Log("Idle Exit");
        _playerController.Input.Movement.Jump.started -= OnJumpStarted;
        _playerController.Animator.StopIdle();
    }

    public void Update()
    {
        if (_playerController.GetHorizontalInput() != 0)
            _stateSwitcher.SwitchState<MovementState>();
    }

    private void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _stateSwitcher.SwitchState<JumpState>();
    }
}
