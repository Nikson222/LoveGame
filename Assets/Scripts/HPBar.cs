using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image _filledImage;
    [SerializeField] private HearthSpawner _hearthesSpawner;
    private BigHearth _currentHearth;
    private float _HealthCount;

    private void Start()
    {
        _filledImage = GetComponent<Image>();
        _hearthesSpawner.OnSpawn += GetNewHearth;
    }

    public void GetNewHearth()
    {
        if (_hearthesSpawner)
        {
            _filledImage.fillAmount = 1;
            _currentHearth = _hearthesSpawner.HearthesList[_hearthesSpawner.HearthesList.Count - 1];
            _HealthCount = _currentHearth.Health;
            _currentHearth.onDamage += SetFilled;
        }
    }
    public void SetFilled()
    {
        
        _filledImage.fillAmount = (_currentHearth.Health / _HealthCount);
    }
}
