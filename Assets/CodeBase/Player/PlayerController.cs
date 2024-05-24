using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;

    [Inject]
    public void Construct(PlayerInput input)
    {
        _input = input;
        _stateMachine = new PlayerStateMachine();
    }
}