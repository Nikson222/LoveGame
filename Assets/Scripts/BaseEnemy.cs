using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private protected float _health;
    [SerializeField] private protected int _killPrize;

    public delegate void DamageNotify();
    public event DamageNotify OnDamage;

    public delegate void DieNotify();
    public event DieNotify OnDie;

    public float Health { get => _health; }

    public void Init(float health, int killPrize)
    {
        _health = health;
        _killPrize = killPrize;
    }

    private protected virtual void GetDamage(int Damage)
    {
        _health -= Damage;

        OnDamage?.Invoke();

        if (_health <= 0)
           Die();
    }

    private protected virtual void Die()
    {
        OnDie?.Invoke();

        Destroy(gameObject);
    }
}
