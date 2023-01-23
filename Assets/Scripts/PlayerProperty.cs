using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour 
{
    private static int  _money = 0;
    private static int _damage = 1;

    public static int Money => _money;
    public static int Damage => _damage;

    public static Action<int> OnMoneyChanged;

    private void Start()
    {
        BaseEnemy.OnGivePrize += CashReceipt;
    }

    private void CashReceipt(int amount)
    {
        _money += amount;

        OnMoneyChanged?.Invoke(Money);
    }

    private void CashWithdrawal(int amount)
    {
        if (_money >= amount)
            _money -= amount;
        else
            Debug.LogError("Money is not enough");

        OnMoneyChanged?.Invoke(Money);
    }
}
