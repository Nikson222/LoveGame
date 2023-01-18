using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHearth : BaseEnemy
{
    [Header("Animation setting")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _scaleAnimation;
    private string _animationHit = "IsHit";
    private float _animationDuration;
    Coroutine _isHitingCoroutine;

    [Header("Image setting")]
    private SpriteRenderer _spriteRenderer;

    [Header("SpawnPosition Settings")]
    [SerializeField] private float _xOffset = 0f;
    [SerializeField] private float _yOffset = 0f;

    #region UnityMetods

    private void Start()
    {
        transform.position += new Vector3(_xOffset, _yOffset, 0);
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animationDuration = _scaleAnimation.length;
    }

    private void OnMouseDown()
    {
        GetDamage(DamageDealer.Damage);
        SetRandomColor();
        StartAnimation();
    }

    #endregion

    #region Metods

    private Color RandomizeColor()
    {
        Color color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
        return color;
    }

    private void SetRandomColor()
    {
        _spriteRenderer.color = RandomizeColor();
    }

    private void StartAnimation()
    {
        if (_isHitingCoroutine != null)
        {
            StopCoroutine(_isHitingCoroutine);
            _animator.SetBool(_animationHit, false);
            _animator.Play("Empty");
        }

        _isHitingCoroutine = StartCoroutine(SetAnimationBool());
    }
    #endregion

    #region IEnumerators
    private IEnumerator SetAnimationBool()
    {
        _animator.SetBool(_animationHit, true);
        yield return new WaitForSeconds(_animationDuration);
        _animator.SetBool(_animationHit, false);
    }
    #endregion
}
