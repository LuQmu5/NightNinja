using UnityEngine.InputSystem;

public class GroundedState : BaseState
{
    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();   
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (Character.OnGround)
            return;

        StateSwitcher.SwitchState<FallState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpState>();
}
