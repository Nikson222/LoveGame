using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScore : MonoBehaviour
{
    [SerializeField] Text _moneyText;
    [SerializeField] Wallet _wallet;
    private void Start()
    {
        UpdateMoneyText();
        _wallet.OnChangedMoneyNotify += UpdateMoneyText;
    }

    void UpdateMoneyText()
    {
        _moneyText.text = $"{_wallet.Money} $";
    }
}
