using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static private int _currentLevel = 0;
    static private int _damage = 1;
    static private int _coins = 0;
    static public int Damage { get => _damage; }
    static public void DamageUpdrade(int count)
    {
        _damage += count;
    }
}
