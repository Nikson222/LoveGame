using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    [SerializeField] GameObject _barPrefab;
    [SerializeField] Transform _canvasParent;
    public void SpawnBarForEnemy(GameObject enemy)
    {
        print("i am here");
        var bar = Instantiate(_barPrefab, _canvasParent.transform);
        bar.transform.SetParent(_canvasParent.transform, true);
    }
}
