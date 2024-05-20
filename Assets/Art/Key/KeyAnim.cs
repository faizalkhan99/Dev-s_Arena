using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnim : MonoBehaviour
{
    [SerializeField] private float _RotateSpeed;
    void Update()
    {
        transform.Rotate(_RotateSpeed * Time.deltaTime * new Vector3(0,1,0));    
    }
}
