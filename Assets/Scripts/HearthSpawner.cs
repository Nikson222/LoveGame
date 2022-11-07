using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSpawner : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> _levelConfigs = new List<LevelConfig>();
    [SerializeField] private int _startLevel = 0;
    public GameObject _currentHearth;

    public delegate void SpawnNotify();
    public event SpawnNotify onSpawn;

   // public GameObject CurrentHearth { get { return _currentHearth; } }

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
        if (_levelConfigs.Count >= levelNum + 1)
        {
            //Break;    
        }
        else if (_levelConfigs.Count >= 1)
            levelNum = _levelConfigs.Count - 1;

        var _tempHearth = _levelConfigs[levelNum].Hearthes[Random.Range(0, _levelConfigs[levelNum].Hearthes.Length)];

        _currentHearth = Instantiate(_tempHearth, transform.position, Quaternion.identity);
        _currentHearth.transform.SetParent(gameObject.transform);

        onSpawn?.Invoke();

    }
}
