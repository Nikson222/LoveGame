using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] RawImage rawImage;

    private static EnemySpawner _spawner;
    private LevelSwitch _levelSwitch;

    private static int _currentLevel = 0;
    private static int _maxAllowedLevel = 0;

    public static int CurrentLevel { get { return _currentLevel; } }
    public static int MaxAllowedLevel { get { return _maxAllowedLevel; } }
    public static int MaximumExistingLevel { get { return _spawner.LevelConfigs.Count; } }

    public static bool IsLastLevel;

    public static Action OnLevelChanged;
    public static Action OnUnlockLevel;

    private void Awake()
    {
        KillCounter.OnTaskComleted += UnlockLevel;
        IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);
    }

    private void Start()
    {
        _spawner = FindObjectOfType<EnemySpawner>();
        if (_spawner == null)
            Debug.Log("Spawner null refference int Gamemanager script!");

        _levelSwitch = FindObjectOfType<LevelSwitch>();
        if (_levelSwitch == null)
            Debug.Log("_levelSwitch null refference int Gamemanager script!");
    }

    public void ChangeLevel(int levelValue)
    {
        if (_currentLevel + levelValue <= _maxAllowedLevel && _currentLevel + levelValue >= 0)
        {
            _currentLevel += levelValue;
            _spawner.ChangeLevel(CurrentLevel);

            if (rawImage != null)
                rawImage.texture = _spawner.LevelConfigs[CurrentLevel].BackgroundTexture;

            IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);
            OnLevelChanged();
        }
    }

    private void UnlockLevel()
    {
        if (MaximumExistingLevel > MaxAllowedLevel+1)
        {
            _maxAllowedLevel += 1;

            IsLastLevel = MaxAllowedLevel.Equals(CurrentLevel);

            OnUnlockLevel();
        }
    }
}
