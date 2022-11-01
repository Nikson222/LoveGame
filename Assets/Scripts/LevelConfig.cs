using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hearthes Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private GameObject[] _hearthes;
    [SerializeField] private int _prizeForDestroy;
    public GameObject[] Hearthes { get { return _hearthes; } }
}
