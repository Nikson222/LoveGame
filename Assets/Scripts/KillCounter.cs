using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private EnemySpawner _spawner;

    public static int NeededKillsOnLastLevel;

    public static int KillCount = 0;

    public static bool _isLastLevel = GameManager.CurrentLevel.Equals(GameManager.MaxAllowedLevel); 

    public static Action OnTaskComleted;

    private void Start()
    {
        _spawner = FindObjectOfType<EnemySpawner>();
        if (_spawner == null)
            Debug.Log("Spawner null refference in KillCounter script!");

        Enemy.OnDie += AddKillCount;
        NewTaskForCounter(_spawner.LevelConfigs[GameManager.MaxAllowedLevel].NeedKillsToNextLevel);
    }

    public void AddKillCount()
    {
        if (_isLastLevel)
        {
            ++KillCount;
            DisplayNeededKills.DisplayUpdate();

            if (KillCount == NeededKillsOnLastLevel)
            {
                OnTaskComleted();
                print(GameManager.CurrentLevel.Equals(GameManager.MaxAllowedLevel));

                NewTaskForCounter(_spawner.LevelConfigs[GameManager.MaxAllowedLevel].NeedKillsToNextLevel);
            }
        }
    }

    public void NewTaskForCounter(int needKills)
    {
        NeededKillsOnLastLevel = needKills;
        KillCount = 0;
    }
}
