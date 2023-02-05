using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElemenToTarget : MonoBehaviour
{
    public Transform TargetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followSpeed;

    private void Update()
    {
        TargetMove();
    }

    private void TargetMove()
    {
        Vector3 newPosition = new Vector3(TargetTransform.position.x + _offset.x, TargetTransform.position.y + _offset.y, TargetTransform.position.z + _offset.z);

        transform.position = Vector3.Slerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
    }
}
