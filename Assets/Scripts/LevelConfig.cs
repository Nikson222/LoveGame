using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Hearthes Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private int _levelIndex;
    [SerializeField] private int _healthOfEnemy;
    [SerializeField] private int _prizeForDestroy;
    [SerializeField] private int _needKillsToNextLevel;
    [SerializeField] private Texture _backgroundTexture;
    public List<GameObject> Hearthes { get { return _enemies; } }
    public int LevelIndex { get { return _levelIndex; } }
    public int HealthOfEnemy { get { return _healthOfEnemy; } }
    public int PrizeForDestroy { get { return _prizeForDestroy; } }
    public int NeedKillsToNextLevel { get { return _needKillsToNextLevel; } }
    public Texture BackgroundTexture { get { return _backgroundTexture; } }
}
