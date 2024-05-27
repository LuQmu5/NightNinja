public class AttackState : CombatState
{
    public AttackState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    protected override void OnAttackEnd()
    {
        StateSwitcher.SwitchState<IdleState>();
    }
}
