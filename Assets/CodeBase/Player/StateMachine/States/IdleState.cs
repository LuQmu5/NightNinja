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
    }

    public void Exit()
    {
        Debug.Log("Idle Exit");
    }

    public void Update()
    {
        if (_playerController.GetHorizontalInput() != 0)
            _stateSwitcher.SwitchState<MovementState>();
    }
}
