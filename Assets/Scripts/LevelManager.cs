using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager InstanceLevelManager;
    
    [SerializeField] private RawImage _backgroundImage;

    [SerializeField] public EnemySpawner _enemySpawner;

    private int _currentLevel = 0;
    private int _maxAllowedLevel = 0;

    public int CurrentLevel { get { return _currentLevel; } }
    public int MaxAllowedLevel { get { return _maxAllowedLevel; } }
    public int MaximumExistingLevel { get { return _enemySpawner.LevelConfigs.Count; } }

    public bool IsLastLevel;

    public Action OnLevelChanged;
    public Action OnUnlockLevel;

    private void Awake()
    {
        InstanceLevelManager = this;
        IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);
    }

    public void ChangeLevel(int levelValue)
    {
        if (_currentLevel + levelValue <= _maxAllowedLevel && _currentLevel + levelValue >= 0)
        {
            _currentLevel += levelValue;
            _enemySpawner.ChangeLevel(CurrentLevel);

            if (_backgroundImage != null)
                _backgroundImage.texture = _enemySpawner.LevelConfigs[CurrentLevel].BackgroundTexture;

            IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);
            OnLevelChanged();
        }
    }

    public void UnlockLevel()
    {
        if (MaximumExistingLevel > MaxAllowedLevel+1)
        {
            _maxAllowedLevel += 1;

            IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);

            OnUnlockLevel();
        }
    }
}
