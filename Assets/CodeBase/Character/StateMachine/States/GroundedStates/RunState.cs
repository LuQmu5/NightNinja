using UnityEngine;

public class RunState : GroundedState
{
    public RunState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartRun();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRun();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdleState>();
    }
}
