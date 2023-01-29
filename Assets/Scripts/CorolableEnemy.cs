using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CorolableEnemy : AnimatedEnemy
{   
    [SerializeField] private ParticleSystem _particleSystem;

    private SpriteRenderer _spriteRenderer;
    
    #region UnityMetods

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected sealed override void GetDamage(int Damage)
    {
        base.GetDamage(Damage);
        SetRandomColor();
    }

    #endregion

    #region Metods

    protected override void Die()
    {
        _particleSystem = Instantiate(_particleSystem);
        _particleSystem.transform.position = transform.position;
        _particleSystem.maxParticles = _killPrize;
        _particleSystem.Play();
        base.Die();
    }
    private Color RandomizeColor()
    {
        Color color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
        return color;
    }

    private void SetRandomColor()
    {
        _spriteRenderer.color = RandomizeColor();
    }
    #endregion
}
