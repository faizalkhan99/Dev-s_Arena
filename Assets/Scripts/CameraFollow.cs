using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset; 
    [SerializeField] private float _smoothTime = 0.3f; 

    private Vector3 velocity = Vector3.zero; 

    void LateUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothTime);
    }
}
