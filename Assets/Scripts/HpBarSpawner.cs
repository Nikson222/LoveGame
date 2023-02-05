using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarSpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private GameObject _hpBarPrefab;

    private void Start()
    {
        _enemySpawner.OnSpawn += CreateHPBarForEnemy;
    }

    public void CreateHPBarForEnemy(Enemy enemy)
    {
        HPBar hpBar = Instantiate(_hpBarPrefab, transform).GetComponent<HPBar>();
        hpBar.EnemyIDisplay = enemy;

        hpBar.GetStartedHealth(enemy);  
    }
}
