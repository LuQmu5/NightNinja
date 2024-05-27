using UnityEngine;

public class JumpState : AirborneState
{
    public JumpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        Data.YVelocity = Character.Config.AirborneStateConfig.JumpPower;

        View.StartJump();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJump();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity < 0)
            StateSwitcher.SwitchState<FallState>();
    }
}