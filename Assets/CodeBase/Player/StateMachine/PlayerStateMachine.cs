using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IStateSwitcher
{
    private IState _currentState;
    private List<IState> _states;

    public PlayerStateMachine()
    {
        _states = new List<IState>()
        {
            new IdleState(),
            new MovementState(),
            new JumpState()
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>(IState state) where T : IState
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
