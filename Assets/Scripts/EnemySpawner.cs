using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Level settings")]
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _currentLevel;
    [SerializeField] private float _respawnColldown = 1f;

    //In the future to spawn many enemies
    //private List<BaseEnemy> _enemiesList = new List<BaseEnemy>();
    //public List<BaseEnemy> EnemiesList { get => _enemiesList; private set => _enemiesList = value; }

    public static Action<BaseEnemy> OnSpawn;

    private void Start()
    {
        BaseEnemy.OnDie += Spawn;
        Spawn();
    }

    private void Spawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(_respawnColldown);

        var enemyIndex = UnityEngine.Random.Range(0, _levelConfigs[_currentLevel].Hearthes.Count - 1);
        var spawnedEnemyObject = Instantiate(_levelConfigs[_currentLevel].Hearthes[enemyIndex], _levelConfigs[_currentLevel].Hearthes[enemyIndex].transform.position, Quaternion.identity);

        spawnedEnemyObject.transform.SetParent(transform, true);

        BaseEnemy spawnedEnemy = spawnedEnemyObject.GetComponent<BaseEnemy>();
        spawnedEnemy.Init(_levelConfigs[_currentLevel].HealthOfEnemy, _levelConfigs[_currentLevel].PrizeForDestroy);

        OnSpawn?.Invoke(spawnedEnemy);
    }
}
