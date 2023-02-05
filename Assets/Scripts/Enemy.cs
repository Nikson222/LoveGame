using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private protected float _health;
    [SerializeField] private protected int _killPrize;

    public Action OnDie;
    public Action OnDestroying;
    public Action<float> OnDamage;
    public Action<float> OnInit;
    public Action<int> OnGivePrize;

    public float Health { get => _health; }
    public int KillPrize { get => _killPrize; }


    private void OnMouseDown()
    {
        GetDamage(PlayerData.Damage);
    }

    public void Init(float health, int killPrize = 0)
    {
        _killPrize = killPrize;
        _health = health;
        OnInit?.Invoke(_health);
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
        OnGivePrize?.Invoke(KillPrize);

        PlayerData.CashReceipt(KillPrize);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDestroying?.Invoke();
    }
}
