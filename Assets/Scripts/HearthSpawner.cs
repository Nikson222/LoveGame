using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSpawner : MonoBehaviour
{
    [Header("Level settings")]
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _startLevel = 0;

    private GameObject _currentHearth;

    public delegate void SpawnNotify();
    public event SpawnNotify onSpawn;


    private void Start()
    {
        Spawn(_startLevel);
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
            Spawn(_startLevel);
    }

    private void Spawn(int levelNum)
    {
        if (_levelConfigs.Count <= levelNum + 1)
            levelNum = _levelConfigs.Count - 1;

        var _tempHearth = _levelConfigs[levelNum].Hearthes[Random.Range(0, _levelConfigs[levelNum].Hearthes.Length)];

        _currentHearth = Instantiate(_tempHearth, transform.position, Quaternion.identity);
        _currentHearth.transform.SetParent(gameObject.transform);

        DamageDealer.AddHearthToList(_currentHearth.GetComponent<Hearth>());

        onSpawn?.Invoke();
    }
}
