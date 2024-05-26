using System.Collections;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsGrounded = nameof(IsGrounded);
    private const string IsIdling = nameof(IsIdling);

    private const string IsJumping = nameof(IsJumping);
    private const string IsFalling = nameof(IsFalling);

    private const string IsMovement = nameof(IsMovement);
    private const string IsAirborne = nameof(IsAirborne);

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StopFalling() => _animator.SetBool(IsFalling, false);

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartRun() => _animator.SetBool(IsMovement, true);
    public void StopRun() => _animator.SetBool(IsMovement, false);
}
