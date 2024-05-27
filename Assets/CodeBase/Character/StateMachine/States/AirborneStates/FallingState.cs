public class FallingState : AirborneState
{
    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        View.StartFall();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFall();
    }

    public override void Update()
    {
        base.Update();

        if (Character.OnGround)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<RunState>();
        }
    }
}
