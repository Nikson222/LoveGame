using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private EnemySpawner _enemySpawner;

    public int NeededKillsOnLastLevel;
    public int KillCount = 0;

    public Action OnCounterChanged;

    private void Start()
    {
        _enemySpawner = LevelManager.InstanceLevelManager._enemySpawner;
        _enemySpawner.OnSpawn += SubscribeOnEnemy;
        NewTaskForCounter();
    }

    private void SubscribeOnEnemy(Enemy enemy)
    {
        enemy.OnDie += AddKillCount;
    }

    public void AddKillCount()
    {
        if (LevelManager.InstanceLevelManager.IsLastLevel && LevelManager.InstanceLevelManager.CurrentLevel < LevelManager.InstanceLevelManager.MaximumExistingLevel - 1)
        {
            KillCount += 1;

            if (KillCount == NeededKillsOnLastLevel)
            {
                LevelManager.InstanceLevelManager.UnlockLevel();
                NewTaskForCounter();
            }

            OnCounterChanged?.Invoke();
        }
    }

    public void NewTaskForCounter()
    {
        NeededKillsOnLastLevel = _enemySpawner.LevelConfigs[LevelManager.InstanceLevelManager.MaxAllowedLevel].NeedKillsToNextLevel;
        KillCount = 0;
        OnCounterChanged?.Invoke();
    }
}
