using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _fillBar;
    [SerializeField] private Text _textHP;

    private float _startHealth;

    public Canvas _canvas;
    public Enemy _enemyIDisplay;

    private void Start()
    {
        _enemyIDisplay.OnDamage += UpdateBarFilling;
        _enemyIDisplay.OnDamage += UpdateBarText;
        _enemyIDisplay.OnInit += UpdateBarFilling;
        _enemyIDisplay.OnInit += UpdateBarText;

        _enemyIDisplay.OnDestroying += SelfDestroy;
    }

    public void GetStartedHealth(Enemy enemy)
    {
        _startHealth = enemy.Health;
        UpdateBarText(_startHealth);
        UpdateBarFilling(_startHealth);
    }

    public void UpdateBarFilling(float Health)
    {
        _fillBar.fillAmount = (Health / _startHealth);
    }

    public void UpdateBarText(float Health)
    {
        _textHP.text = $"({Health} / {_startHealth})";
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
