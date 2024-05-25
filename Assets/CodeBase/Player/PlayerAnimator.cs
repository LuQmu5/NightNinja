using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.SetBool("Idle", true);
    }

    public void StopIdle()
    {
        _animator.SetBool("Idle", false);
    }

    public void StartMove()
    {
        _animator.SetBool("Move", true);
    }

    public void StopMove()
    {
        _animator.SetBool("Move", false);
    }

    public void StartJump()
    {
        _animator.SetBool("Jump", true);
    }

    public void StopJump()
    {
        _animator.SetBool("Jump", false);
    }
}