using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Level settings")]
    private int _currentLevel;
    
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();

    [SerializeField] private float _respawnColldown = 1f;

    public List<LevelConfig> LevelConfigs => _levelConfigs;

    public static Action<Enemy> OnSpawn;

    public int CurrentLevel => _currentLevel;

    private void Awake()
    {
        _currentLevel = GameManager.CurrentLevel;
    }

    private void Start()
    {
        Enemy.OnDie += Spawn;
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

        Enemy spawnedEnemy = spawnedEnemyObject.GetComponent<Enemy>();
        spawnedEnemy.Init(_levelConfigs[_currentLevel].HealthOfEnemy, _levelConfigs[_currentLevel].PrizeForDestroy);

        OnSpawn?.Invoke(spawnedEnemy);
    }

    private void ClearLastLevelEnemies()
    {
        foreach (var enemy in transform.GetComponentsInChildren<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
    }

    public void ChangeLevel(int levelNum)
    {
        if (levelNum < _levelConfigs.Count)
        {
            _currentLevel = levelNum;
            ClearLastLevelEnemies();
            StartCoroutine(SpawnCoroutine());
        }
    }
}
