using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearth : MonoBehaviour
{
    [Header("Base stats")]
    [SerializeField] private float _health;
    public float Health { get => _health; }

    [Header("Animation setting")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _scaleAnimation;
    private string _animationHit = "IsHit";
    private float _animationDuration;
    Coroutine _isHitingCoroutine;

    [Header("Image setting")]
    private Image _image;

    public delegate void DamageNotify();
    public event DamageNotify onDamage;

    #region UnityMetods

    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _animationDuration = _scaleAnimation.length;
    }

    #endregion

    #region Metods
    public void GetDamage()
    {

        if (_isHitingCoroutine != null)
        {
            StopCoroutine(_isHitingCoroutine);
            _animator.SetBool(_animationHit, false);
            _animator.Play("Empty");
        }

        _isHitingCoroutine = StartCoroutine(SetAnimationBool());

        _health -= PlayerStats.Damage;
        SetRandomColor();

        onDamage?.Invoke();

        if(_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private Color RandomizeColor()
    {
       Color color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
        return color;
    }

    private void SetRandomColor()
    {
        _image.color = RandomizeColor();
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
