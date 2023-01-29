using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] RawImage rawImage;

    private EnemySpawner _spawner;

    private static int _currentLevel = 0;
    private static int _maxAllowedLevel = 0;

    public static int CurrentLevel { get { return _currentLevel; } }
    public static int MaxAllowedLevel { get { return _maxAllowedLevel; } }


    public static Action OnLevelChanged;

    private void Awake()
    {
        KillCounter.OnTaskComleted += UnlockLevel;
    }
       
    private void Start()
    {
        _spawner = FindObjectOfType<EnemySpawner>();
        if (_spawner == null)
            Debug.Log("Spawner null refference int Gamemanager script!");
    }

    public void ChangeLevel(int levelValue)
    {
        if (_currentLevel + levelValue <= _maxAllowedLevel && _currentLevel + levelValue >= 0)
        {
            _currentLevel += levelValue;
            _spawner.ChangeLevel(CurrentLevel);

            DisplayLevel.DisplayUpdate();

            OnLevelChanged();

            if (rawImage != null)
                rawImage.texture = _spawner.LevelConfigs[CurrentLevel].BackgroundTexture;

            DisplayNeededKills.UpdateVisibleText();
        }
    }

    public void UnlockLevel()
    {
        if (_spawner.LevelConfigs.Count > MaxAllowedLevel+1)
        {
            _maxAllowedLevel++;
            DisplayNeededKills.UpdateVisibleText();
        }
    }
}
