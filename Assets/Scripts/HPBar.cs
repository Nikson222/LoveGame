using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image _fillBar;

    private float _startHealth;

    private void Start()
    {
        BaseEnemy.OnDamage += UpdateBarFilling;
        BaseEnemy.OnInit += UpdateBarFilling;
        EnemySpawner.OnSpawn += GetStartedHealth;
    }

    private void GetStartedHealth(BaseEnemy enemy)
    {
        _startHealth = enemy.Health;
    }

    private void UpdateBarFilling(float Health)
    {
        _fillBar.fillAmount = (Health / _startHealth);
    }
}
