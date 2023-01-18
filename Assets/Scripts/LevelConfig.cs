using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hearthes Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private int _level;
    [SerializeField] private int _healthOfEnemy;
    [SerializeField] private int _prizeForDestroy;
    public List<GameObject> Hearthes { get { return _enemies; } }
    public int HealthOfEnemy { get { return _healthOfEnemy; } }
    public int PrizeForDestroy { get { return _prizeForDestroy; } }
}
