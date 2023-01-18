using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private protected float _health;

    public static Action<float> OnDamage;
    public static Action OnDie;

    public float Health { get => _health; }


    private void OnMouseDown()
    {
        GetDamage(DamageDealer.Damage);
    }

    public void Init(float health)
    {
        _health = health;
    }

    protected virtual void GetDamage(int Damage)
    {
        _health -= Damage;

        OnDamage?.Invoke(Health);

        if (_health <= 0)
           Die();
    }

    protected virtual void Die()
    {
        OnDie?.Invoke();

        Destroy(gameObject);
    }
}
