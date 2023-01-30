using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class DisplayNeededKills : MonoBehaviour
{
    [SerializeField] EnemySpawner _enemySpawner;
    private static Text _killsText;
    void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        if (_enemySpawner == null)
            Debug.Log("Spawner null refference int DisplayNeededKills script!");

        GameManager.OnUnlockLevel += DisplayUpdate;
        GameManager.OnUnlockLevel += UpdateVisibleText;

        GameManager.OnLevelChanged += DisplayUpdate;
        GameManager.OnLevelChanged += UpdateVisibleText;

        _killsText = GetComponent<Text>();
        _killsText.text = $"{KillCounter.NeededKillsOnLastLevel - KillCounter.KillCount} need to next level";
    }

    static public void DisplayUpdate()
    {
        _killsText.text = $"{KillCounter.NeededKillsOnLastLevel - KillCounter.KillCount} need to next level";
    }

    public void UpdateVisibleText()
    {
        _killsText.gameObject.SetActive(GameManager.MaxAllowedLevel.Equals(GameManager.CurrentLevel) && GameManager.CurrentLevel < GameManager.MaximumExistingLevel-1);
    }
}
