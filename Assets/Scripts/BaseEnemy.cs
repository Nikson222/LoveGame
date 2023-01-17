using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private protected float _health;
    [SerializeField] private protected int _killPrize;

    public delegate void DamageNotify();
    public event DamageNotify onDamage;
    public delegate void DieNotify(BigHearth hearth);
    public event DieNotify onDie;
    public float Health { get => _health; }

    public virtual void GetDamage(int Damage)
    {
        _health -= Damage;
        onDamage?.Invoke();
        if (_health <= 0)
           Die();
    }

    private protected virtual void Die()
    {
        Wallet.Instance.PutMoney(_killPrize);
        Destroy(gameObject);
    }
}
