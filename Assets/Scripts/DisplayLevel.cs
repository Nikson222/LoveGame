using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class DisplayLevel : MonoBehaviour
{
    private static Text _levelText;
    void Start()
    {
        _levelText = GetComponent<Text>();
        _levelText.text = $"{GameManager.CurrentLevel+1}";
    }
    
    static public void DisplayUpdate()
    {
        _levelText.text = $"{GameManager.CurrentLevel + 1}";
    }
}
