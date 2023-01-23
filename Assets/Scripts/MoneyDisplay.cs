using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        UpdateMoneyText(PlayerProperty.Money);
        PlayerProperty.OnMoneyChanged += UpdateMoneyText;    
    }

    private void UpdateMoneyText(int Money)
    {
        _moneyText.text = $"{Money}";
    }
}
