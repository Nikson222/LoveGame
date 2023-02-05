using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField] private Button _levelDownButton;
    [SerializeField] private Button _levelUpButton;

    private void Start()
    {
        SetInteractable();
        LevelManager.InstanceLevelManager.OnLevelChanged += SetInteractable;
        LevelManager.InstanceLevelManager.OnUnlockLevel += SetInteractable;
    }

    void SetInteractable()
    {
        _levelDownButton.interactable = LevelManager.InstanceLevelManager.CurrentLevel > 0;
        _levelUpButton.interactable = !LevelManager.InstanceLevelManager.IsLastLevel;
    }
}
