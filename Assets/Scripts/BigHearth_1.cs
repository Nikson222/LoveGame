using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearth : BaseEnemy
{
    //[Header("Animation setting")]
    //[SerializeField] private Animator _animator;
    //[SerializeField] private AnimationClip _scaleAnimation;
    //private string _animationHit = "IsHit";
    //private float _animationDuration;
    //Coroutine _isHitingCoroutine;

    //[Header("Image setting")]
    //private SpriteRenderer _spriteRenderer;

    //public delegate void DamageNotify();
    //public event DamageNotify onDamage;
    //public delegate void DieNotify(Hearth hearth);
    //public event DieNotify onDie;

    //#region UnityMetods

    //private void Start()
    //{
    //    _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    //    _animationDuration = _scaleAnimation.length;
    //}

    //private void OnMouseDown()
    //{
    //    GetDamage(DamageDealer.Damage);
    //}

    //#endregion

    //#region Metods
    //public override void GetDamage(int Damage)
    //{
    //    _health -= Damage;

    //    SetRandomColor();
    //    StartAnimation();

    //    onDamage?.Invoke();

    //    if (_health <= 0)
    //        Die();
    //}

    //private protected override void Die()
    //{
    //    onDie?.Invoke(this);
    //    Wallet.Instance.PutMoney(_killPrize);
    //    Destroy(gameObject);
    //}

    //private Color RandomizeColor()
    //{
    //   Color color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
    //    return color;
    //}

    //private void SetRandomColor()
    //{
    //    _spriteRenderer.color = RandomizeColor();
    //}

    //private void StartAnimation()
    //{
    //    if (_isHitingCoroutine != null)
    //    {
    //        StopCoroutine(_isHitingCoroutine);
    //        _animator.SetBool(_animationHit, false);
    //        _animator.Play("Empty");
    //    }

    //    _isHitingCoroutine = StartCoroutine(SetAnimationBool());
    //}
    //#endregion

    //#region IEnumerators
    //private IEnumerator SetAnimationBool()
    //{
    //    _animator.SetBool(_animationHit, true);
    //    yield return new WaitForSeconds(_animationDuration);
    //    _animator.SetBool(_animationHit, false);
    //}
    //#endregion
}