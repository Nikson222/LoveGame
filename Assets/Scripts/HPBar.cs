using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] EnemySpawner _enemySpawner;

    [SerializeField] Image _fillBar;
    private float _startHealth;

    private void Start()
    {
        _enemySpawner.OnSpawn += SubscribeMethodToEnemy;

        foreach (var enemy in _enemySpawner.EnemiesList)
        {
            enemy.OnDamage += UpdateBarFilling;
            _startHealth += enemy.Health;
        }

        UpdateBarFilling();
    }

    private void SubscribeMethodToEnemy()
    {
        if(_enemySpawner.EnemiesList.Count > 0)
            _enemySpawner.EnemiesList[_enemySpawner.EnemiesList.Count-1].OnDamage += UpdateBarFilling;
    }

    private void UpdateBarFilling()
    {
        float summuryHealthPoints = 0;
        if (_enemySpawner.EnemiesList.Count > 1)
        {
            foreach (var enemy in _enemySpawner.EnemiesList)
            {
                summuryHealthPoints += enemy.Health;
            }
        }
        else if(_enemySpawner.EnemiesList.Count < 1 && _enemySpawner.EnemiesList.Count > 0)
            summuryHealthPoints += _enemySpawner.EnemiesList[0].Health;

        _fillBar.fillAmount = (summuryHealthPoints / _startHealth);
    }
}
