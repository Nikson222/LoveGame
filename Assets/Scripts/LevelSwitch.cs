using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField] private Button ChangeLevelDown;
    [SerializeField] private Button ChangeLevelUp;

    private void Start()
    {
        SetInteractable();
    }

    void SetInteractable()
    {
        ChangeLevelDown.interactable = GameManager.CurrentLevel > 0;
        ChangeLevelUp.interactable = !GameManager.IsLastLevel;
    }
}
