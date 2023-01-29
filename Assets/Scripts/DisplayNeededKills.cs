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
        _killsText = GetComponent<Text>();
        _killsText.text = $"{KillCounter.NeededKillsOnLastLevel - KillCounter.KillCount} need to next level";
    }

    static public void DisplayUpdate()
    {
        _killsText.text = $"{KillCounter.NeededKillsOnLastLevel - KillCounter.KillCount} need to next level";
    }

    public static void UpdateVisibleText()
    {
        _killsText.gameObject.SetActive(GameManager.CurrentLevel.Equals(GameManager.MaxAllowedLevel));
    }
}
