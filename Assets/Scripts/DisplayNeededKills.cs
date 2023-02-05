using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class DisplayNeededKills : MonoBehaviour
{
    [SerializeField] KillCounter _killCounter;

    private Text _killsText;

    void Start()
    {
        GameManager.InstanceGamemanager.OnUnlockLevel += DisplayUpdate;
        GameManager.InstanceGamemanager.OnUnlockLevel += UpdateVisibleText;

        GameManager.InstanceGamemanager.OnLevelChanged += DisplayUpdate;
        GameManager.InstanceGamemanager.OnLevelChanged += UpdateVisibleText;

        _killCounter.OnCounterChanged += DisplayUpdate;

        _killsText = GetComponent<Text>();
        _killsText.text = $"{_killCounter.NeededKillsOnLastLevel - _killCounter.KillCount} need to next level";
    }

    public void DisplayUpdate()
    {
        _killsText.text = $"{_killCounter.NeededKillsOnLastLevel - _killCounter.KillCount} need to next level";
    }

    public void UpdateVisibleText()
    {
        _killsText.gameObject.SetActive(GameManager.InstanceGamemanager.MaxAllowedLevel.Equals(GameManager.InstanceGamemanager.CurrentLevel) && 
            GameManager.InstanceGamemanager.CurrentLevel < GameManager.InstanceGamemanager.MaximumExistingLevel-1);
    }
}
