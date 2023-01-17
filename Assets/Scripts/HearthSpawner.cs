using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSpawner : MonoBehaviour
{
    [Header("Level settings")]
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _startLevel = 0;

    private List<BigHearth> _hearthesList = new List<BigHearth>();
    public List<BigHearth> HearthesList { get => _hearthesList; private set => _hearthesList = value; }

    public delegate void SpawnNotify();
    public event SpawnNotify OnSpawn;


    private void Start()
    {
        if (_hearthesList.Count.Equals(0))
            Spawn(_startLevel);
    }

    private void Spawn(int levelNum)
    {
        if (_levelConfigs.Count <= levelNum + 1)
            levelNum = _levelConfigs.Count - 1;

        var _tempHearth = _levelConfigs[levelNum].Hearthes[Random.Range(0, _levelConfigs[levelNum].Hearthes.Length)];

        _hearthesList.Add(Instantiate(_tempHearth, transform.position, Quaternion.identity).GetComponent<BigHearth>());

        OnSpawn?.Invoke();
    }
}
