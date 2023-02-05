using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayLevel : MonoBehaviour
{
    private Text _levelText;

    void Start()
    {
        LevelManager.InstanceLevelManager.OnLevelChanged += DisplayUpdate;

        _levelText = GetComponent<Text>();
        _levelText.text = $"{LevelManager.InstanceLevelManager.CurrentLevel+1}";
    }
    
    private void DisplayUpdate()
    {
        _levelText.text = $"{LevelManager.InstanceLevelManager.CurrentLevel + 1}";
    }
}
