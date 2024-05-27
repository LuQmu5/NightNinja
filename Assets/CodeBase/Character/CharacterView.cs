using System.Collections;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsGrounded = nameof(IsGrounded);
    private const string IsAirborne = nameof(IsAirborne);

    private const string IsIdle = nameof(IsIdle);
    private const string IsRun = nameof(IsRun);
    private const string IsJump = nameof(IsJump);
    private const string IsFall = nameof(IsFall);

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void StartRun() => _animator.SetBool(IsRun, true);
    public void StopRun() => _animator.SetBool(IsRun, false);

    public void StartJump() => _animator.SetBool(IsJump, true);
    public void StopJump() => _animator.SetBool(IsJump, false);

    public void StartFall() => _animator.SetBool(IsFall, true);
    public void StopFall() => _animator.SetBool(IsFall, false);
}
