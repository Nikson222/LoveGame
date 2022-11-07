using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class DamageDealer : MonoBehaviour
{
    [Header("Damage stats")]
    [SerializeField] private int _damage = 1;

    [Header("Info of current hearthes")]
    [SerializeField] private List<Hearth> _currentHearthes;

    public int Damage { get => _damage; }
    public static DamageDealer _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static void AddHearthToList(Hearth hearth)
    {
        _instance._currentHearthes.Add(hearth);
        _instance._currentHearthes[_instance._currentHearthes.Count - 1].onDie += RemoveHearthFromList;
    }
    public static void RemoveHearthFromList(Hearth hearth)
    {
        _instance._currentHearthes.Remove(hearth);
    }
}
