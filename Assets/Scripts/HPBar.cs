using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image _filledImage;
    [SerializeField] private GameObject _hearthesSpawner;
    private Hearth _currentHearth;
    private float _tempStartHealth;

    private void Start()
    {
        _filledImage = GetComponent<Image>();
        _hearthesSpawner.GetComponent<HearthSpawner>().onSpawn += GetNewHearth;
    }

    public void GetNewHearth()
    {
        _filledImage.fillAmount = 1;
        _currentHearth = _hearthesSpawner.GetComponentInChildren<Hearth>();
        _tempStartHealth = _currentHearth.Health;
        _currentHearth.onDamage += SetFilled;
    }
    public void SetFilled()
    {
        _filledImage.fillAmount = (_currentHearth.Health / _tempStartHealth);
    }
}
