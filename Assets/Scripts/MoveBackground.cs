using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class MoveBackground : MonoBehaviour
{
    private RawImage rawImage;
    [SerializeField] private float _xSpeed, _ySpeed;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
    }
    private void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(_xSpeed, _ySpeed) * Time.deltaTime, rawImage.uvRect.size);
    }
}
