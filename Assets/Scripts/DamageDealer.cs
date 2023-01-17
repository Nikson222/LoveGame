using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class DamageDealer : MonoBehaviour
{
    [Header("Damage stats")]
    [SerializeField] private static int _damage = 1;
    [SerializeField] private int _money = 0;

    public static int Damage { get => _damage; }
}
