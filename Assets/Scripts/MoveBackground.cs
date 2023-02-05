using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class MoveBackground : MonoBehaviour
{
    private RawImage _rawImage;
    [SerializeField] private float _xSpeed, _ySpeed;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }
    private void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + new Vector2(_xSpeed, _ySpeed) * Time.deltaTime, _rawImage.uvRect.size);
    }
}
