using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSpawner : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _startLevel = 0;
    private GameObject _currentHearth;

    public delegate void SpawnNotify();
    public event SpawnNotify onSpawn;

    public GameObject CurrentHearth { get { return _currentHearth; } }

    private void Start()
    {
        Spawn(_startLevel);    
    }

    //event спавна в методе Die();
    private void Update()
    {
        if (!_currentHearth)
        {
            Spawn(0);
        }
    }

    private void Spawn(int levenNum)
    {
        _currentHearth = Instantiate(_levelConfigs[levenNum].Hearthes[Random.Range(0, _levelConfigs[levenNum].Hearthes.Length)], transform.position, Quaternion.identity);
        _currentHearth.transform.SetParent(gameObject.transform);
        onSpawn?.Invoke();
    }
}
