using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KillCounter))]
public class LevelUnlocker : MonoBehaviour
{
    private KillCounter _KillCounter;
    [SerializeField] DisplayNeededKills _displayNeededKillsToUnlock;

    private void Start()
    {
        _KillCounter = GetComponent<KillCounter>();
    }

}
