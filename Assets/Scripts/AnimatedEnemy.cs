using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatedEnemy : BaseEnemy
{
    [Header("Animation setting")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _scaleAnimation;
    [SerializeField] private string _parametrName;

    Coroutine _isHitingCoroutine;

    public Animator Animator => _animator;
    public AnimationClip AnimationClip => _scaleAnimation;
    public string ParametrName => _parametrName;


    protected override void GetDamage(int Damage)
    {
        base.GetDamage(Damage);
        StartAnimation();
    }

    protected virtual void StartAnimation()
    {
        if (_animator.GetBool(_parametrName).Equals(true))
        {
            _animator.SetBool(_parametrName, false);
            StopCoroutine(_isHitingCoroutine);
        }

        _isHitingCoroutine = StartCoroutine(SetAnimationBoolCoroutine());
    }


    #region IEnumerators
    protected virtual IEnumerator SetAnimationBoolCoroutine()
    {
        yield return new WaitForSeconds(0.001f);
        _animator.SetBool(_parametrName, true);
        yield return new WaitForSeconds(_scaleAnimation.averageDuration);
        _animator.SetBool(_parametrName, false);
    }
    #endregion
}
