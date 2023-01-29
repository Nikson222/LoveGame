using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _fillBar;
    [SerializeField] private Text _textHP;

    private float _startHealth;

    private void Start()
    {
        EnemySpawner.OnSpawn += GetStartedHealth;
        Enemy.OnDamage += UpdateBarFilling;
        Enemy.OnDamage += UpdateBarText;
        Enemy.OnInit += UpdateBarFilling;
        Enemy.OnInit += UpdateBarText;
    }

    private void GetStartedHealth(Enemy enemy)
    {
        _startHealth = enemy.Health;
        UpdateBarText(_startHealth);
        UpdateBarFilling(_startHealth);
    }

    private void UpdateBarFilling(float Health)
    {
        _fillBar.fillAmount = (Health / _startHealth);
    }

    private void UpdateBarText(float Health)
    {
        _textHP.text = $"({Health} / {_startHealth})";
    }
}
