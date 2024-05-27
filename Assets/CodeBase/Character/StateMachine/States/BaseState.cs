using UnityEngine;

public abstract class BaseState : IState
{
    protected IStateSwitcher StateSwitcher;
    protected StateMachineData Data;
    protected Character Character;

    protected BaseState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }

    protected PlayerInput Input => Character.Input;
    protected Rigidbody2D Rigidbody => Character.Rigidbody;
    protected CharacterView View => Character.View;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        Debug.Log(GetType());

        Data.Speed = Character.Config.GroundedStateConfig.Speed;

        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector2 velocity = GetConvertedVelocity();
        Rigidbody.velocity = velocity;
        Character.transform.rotation = GetRotationFrom(velocity);
    }

    protected virtual void AddInputActionsCallbacks() 
    {
        Input.Combat.Attack.started += OnAttack;
    }

    protected virtual void RemoveInputActionsCallbacks() 
    {
        Input.Combat.Attack.started -= OnAttack;
    }

    private void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Character.IsAttacking)
            return;

        if (Character.OnGround)
            StateSwitcher.SwitchState<AttackState>();
        else
            StateSwitcher.SwitchState<JumpAttackState>();
    }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Vector2 GetConvertedVelocity() => new Vector2(Data.XVelocity, Data.YVelocity);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return Character.transform.rotation;
    }
}
