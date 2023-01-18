using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Level settings")]
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _currentLevel;
    [SerializeField] private float _respawnColldown = 1f;

    //[SerializeField] private HPBarManager _HPBarManager;

    private List<BaseEnemy> _enemiesList = new List<BaseEnemy>();
    public List<BaseEnemy> EnemiesList { get => _enemiesList; private set => _enemiesList = value; }

    public delegate void SpawnNotify();
    public event SpawnNotify OnSpawn;

    private void Start()
    {
        CleanLevel();
        Spawn();
    }

    private void Spawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void CleanLevel()
    {
        foreach (var enemy in _enemiesList)
        {
            Destroy(enemy.gameObject);
        }
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(_respawnColldown);

        var spawnedEnemyObject = Instantiate(_levelConfigs[_currentLevel].Hearthes[Random.Range(0, _levelConfigs[_currentLevel].Hearthes.Count-1)], transform.position, Quaternion.identity);
        spawnedEnemyObject.transform.SetParent(transform, true);

        BaseEnemy spawnedEnemy = spawnedEnemyObject.GetComponent<BaseEnemy>();

        OnSpawn?.Invoke();

        spawnedEnemy.OnDie += Spawn;

        //_HPBarManager?.SpawnBarForEnemy(spawnedEnemyObject);
    }
}
