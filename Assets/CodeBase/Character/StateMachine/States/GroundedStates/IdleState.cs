public class IdleState : GroundedState
{
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = 0;

        View.StartIdle();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdle();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitchState<RunState>();
    }
}
