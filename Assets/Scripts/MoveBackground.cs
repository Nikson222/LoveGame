using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        _renderer.material.mainTextureOffset -= new Vector2(_speed * Time.deltaTime, 0f);
    }
}
