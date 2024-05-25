using UnityEngine;

public class MovementState : IState
{
    private PlayerController _playerController;
    private PlayerStatsConfig _config;
    private IStateSwitcher _stateSwitcher;

    public MovementState(PlayerController playerController, PlayerStatsConfig config, IStateSwitcher stateSwitcher)
    {
        _playerController = playerController;
        _config = config;
        _stateSwitcher = stateSwitcher;
    }

    public void Enter()
    {
        Debug.Log("Movement Enter");
    }

    public void Exit()
    {
        Debug.Log("Movement Exit");
    }

    public void Update()
    {
        if (_playerController.GetHorizontalInput() == 0)
            _stateSwitcher.SwitchState<IdleState>();

        _playerController.Rigidbody.velocity = new Vector2
        {
            x = _playerController.GetHorizontalInput() * _config.Speed,
            y = _playerController.Rigidbody.velocity.y
        };
    }
}
