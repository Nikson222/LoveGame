using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int NeededKillsOnLastLevel;

    public int KillCount = 0;

    private EnemySpawner _enemySpawner;

    public Action OnCounterChanged;

    private void Start()
    {
        _enemySpawner = GameManager.InstanceGamemanager._enemySpawner;
        _enemySpawner.OnSpawn += SubscribeOnEnemy;
        NewTaskForCounter();
    }

    private void SubscribeOnEnemy(Enemy enemy)
    {
        enemy.OnDie += AddKillCount;
    }

    public void AddKillCount()
    {
        if (GameManager.InstanceGamemanager.IsLastLevel && GameManager.InstanceGamemanager.CurrentLevel < GameManager.InstanceGamemanager.MaximumExistingLevel - 1)
        {
            KillCount += 1;

            if (KillCount == NeededKillsOnLastLevel)
            {
                GameManager.InstanceGamemanager.UnlockLevel();
                NewTaskForCounter();
            }

            OnCounterChanged?.Invoke();
        }
    }

    public void NewTaskForCounter()
    {
        NeededKillsOnLastLevel = _enemySpawner.LevelConfigs[GameManager.InstanceGamemanager.MaxAllowedLevel].NeedKillsToNextLevel;
        KillCount = 0;
        OnCounterChanged?.Invoke();
    }
}
