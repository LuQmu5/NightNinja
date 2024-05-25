using UnityEngine;

public class JumpState : IState
{
    private PlayerController _playerController;
    private IStateSwitcher _stateSwitcher;

    public JumpState(PlayerController playerController, IStateSwitcher stateSwitcher)
    {
        _playerController = playerController;
        _stateSwitcher = stateSwitcher;
    }

    public void Enter()
    {
        Debug.Log("Jump Enter");
        _playerController.Animator.StartJump();
        _playerController.Rigidbody.AddForce(Vector2.up * _playerController.StatsConfig.JumpPower, ForceMode2D.Impulse);
    }

    public void Exit()
    {
        _playerController.Animator.StopJump();
        Debug.Log("Jump Exit");
    }

    public void Update()
    {
        _playerController.Rigidbody.velocity = new Vector2
        {
            x = _playerController.GetHorizontalInput() * _playerController.StatsConfig.AirSpeed,
            y = _playerController.Rigidbody.velocity.y
        };

        if (Mathf.Abs(_playerController.Rigidbody.velocity.y) < 0.1f && _playerController.OnGround())
            _stateSwitcher.SwitchState<IdleState>();
    }
}
