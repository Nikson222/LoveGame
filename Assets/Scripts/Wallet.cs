using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;
    
    [SerializeField] private int _money;
    public int Money { get { return _money; } }

    public delegate void ChangedMoneyNotify();
    public event ChangedMoneyNotify OnChangedMoneyNotify;

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void WithdrowMoney(int value)
    {
        _money -= value;
        OnChangedMoneyNotify?.Invoke();
    }

    public void PutMoney(int value)
    {
        _money += value;
        OnChangedMoneyNotify?.Invoke();
    }
}
