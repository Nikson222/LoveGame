using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayNeededKills : MonoBehaviour
{
    [SerializeField] KillCounter _killCounter;

    private Text _killsText;

    private void Start()
    {
        LevelManager.InstanceLevelManager.OnUnlockLevel += DisplayUpdate;
        LevelManager.InstanceLevelManager.OnUnlockLevel += UpdateVisibleText;

        LevelManager.InstanceLevelManager.OnLevelChanged += DisplayUpdate;
        LevelManager.InstanceLevelManager.OnLevelChanged += UpdateVisibleText;

        _killCounter.OnCounterChanged += DisplayUpdate;

        _killsText = GetComponent<Text>();
        _killsText.text = $"{_killCounter.NeededKillsOnLastLevel - _killCounter.KillCount} need to next level";
    }

    private void DisplayUpdate()
    {
        _killsText.text = $"{_killCounter.NeededKillsOnLastLevel - _killCounter.KillCount} need to next level";
    }

    private void UpdateVisibleText()
    {
        _killsText.gameObject.SetActive(LevelManager.InstanceLevelManager.MaxAllowedLevel.Equals(LevelManager.InstanceLevelManager.CurrentLevel) && 
            LevelManager.InstanceLevelManager.CurrentLevel < LevelManager.InstanceLevelManager.MaximumExistingLevel-1);
    }
}
