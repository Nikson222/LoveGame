using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // public static GameManager instance;

    [SerializeField] RawImage rawImage;

    private static EnemySpawner _spawner;
    private LevelSwitch _levelSwitch;

    private static int _currentLevel = 0;
    private static int _maxAllowedLevel = 0;

    public static int CurrentLevel { get { return _currentLevel; } }
    public static int MaxAllowedLevel { get { return _maxAllowedLevel; } }

    public static bool IsLastLevel = CurrentLevel == MaxAllowedLevel;

    public static Action OnLevelChanged;
    public static Action OnUnlockLevel;

    private void Awake()
    {
        KillCounter.OnTaskComleted += UnlockLevel;
    }

    private void Start()
    {
        //instance = this;

        _spawner = FindObjectOfType<EnemySpawner>();
        if (_spawner == null)
            Debug.Log("Spawner null refference int Gamemanager script!");

        _levelSwitch = FindObjectOfType<LevelSwitch>();
        if (_levelSwitch == null)
            Debug.Log("_levelSwitch null refference int Gamemanager script!");

    }

    private void Update()
    {
        print(MaxAllowedLevel);

    }
    public void ChangeLevel(int levelValue)
    {
        if (_currentLevel + levelValue <= _maxAllowedLevel && _currentLevel + levelValue >= 0)
        {
            _currentLevel += levelValue;
            _spawner.ChangeLevel(CurrentLevel);


            if (rawImage != null)
                rawImage.texture = _spawner.LevelConfigs[CurrentLevel].BackgroundTexture;

            OnLevelChanged();
        }
    }

    public void UnlockLevel()
    {
        if (_spawner.LevelConfigs.Count > MaxAllowedLevel)
        {
            _maxAllowedLevel += 1;
            //print(CurrentLevel);
            //print(_maxAllowedLevel);
            //print(IsLastLevel);


            OnUnlockLevel();
        }
    }
}
