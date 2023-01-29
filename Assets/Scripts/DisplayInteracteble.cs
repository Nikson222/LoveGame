
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class DisplayInteracteble : MonoBehaviour
{
    private Button _button;
    [SerializeField] private bool isDowngradeButton = false;

    private void Start()
    {
        _button = GetComponent<Button>();

        GameManager.OnLevelChanged += SetInteractable;
        KillCounter.OnTaskComleted += SetInteractable;

        if (isDowngradeButton) _button.interactable = GameManager.CurrentLevel > 0;
        else _button.interactable = GameManager.CurrentLevel < GameManager.MaxAllowedLevel;
    }

    void SetInteractable()
    {
        if (isDowngradeButton) _button.interactable = GameManager.CurrentLevel > 0;
        else _button.interactable = GameManager.CurrentLevel < GameManager.MaxAllowedLevel;
    }
}
