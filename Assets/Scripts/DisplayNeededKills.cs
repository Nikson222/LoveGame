using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class DisplayNeededKills : MonoBehaviour
{
    private static Text _killsText;
    void Start()
    {
        GameManager.OnUnlockLevel += UpdateVisibleText;
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
        _killsText.gameObject.SetActive(GameManager.MaxAllowedLevel.Equals(GameManager.CurrentLevel));
    }
}
