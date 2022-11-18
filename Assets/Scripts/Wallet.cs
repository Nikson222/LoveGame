using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;
    
    private int _money;
    public int Money { get { return _money; } }

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    private void WithdrowMoney(int value)
    {
        _money -= value;
    }

    private void PutMoney(int value)
    {
        _money += value;
    }
}
