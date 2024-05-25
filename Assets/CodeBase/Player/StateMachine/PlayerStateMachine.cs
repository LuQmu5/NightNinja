using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateMachine : IStateSwitcher
{
    private IState _currentState;
    private List<IState> _states;

    public PlayerStateMachine(PlayerController playerController, PlayerStatsConfig playerStatsConfig)
    {
        _states = new List<IState>()
        {
            new IdleState(playerController, this),
            new MovementState(playerController, playerStatsConfig, this),
            new JumpState()
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(s => s.GetType() == typeof(T));

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }
}
