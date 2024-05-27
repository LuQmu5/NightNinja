using System.Collections;
using UnityEngine;

public abstract class CombatState : BaseState
{
    protected CombatState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Character.View.StartCombat();
        Character.StartAttack();

        Character.StartCoroutine(WaitingForAttackEnd());
    }

    public override void Exit()
    {
        Character.View.StopCombat();
        Character.StopAttack();

        base.Exit();
    }

    private IEnumerator WaitingForAttackEnd()
    {
        yield return new WaitForEndOfFrame();

        float attackDuration = Character.View.GetCurrentAnimationLength();
        Debug.Log(attackDuration);

        yield return new WaitForSeconds(attackDuration);

        OnAttackEnd();
    }

    protected abstract void OnAttackEnd();
}

public class JumpAttackState : CombatState
{
    public JumpAttackState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Character.View.StartJump();
    }

    protected override void OnAttackEnd()
    {
        StateSwitcher.SwitchState<FallState>();
    }
}