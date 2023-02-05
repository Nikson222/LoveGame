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
        GameManager.InstanceGamemanager.OnLevelChanged += SetInteractable;
        GameManager.InstanceGamemanager.OnUnlockLevel += SetInteractable;
    }

    void SetInteractable()
    {
        ChangeLevelDown.interactable = GameManager.InstanceGamemanager.CurrentLevel > 0;
        ChangeLevelUp.interactable = !GameManager.InstanceGamemanager.IsLastLevel;
    }
}
