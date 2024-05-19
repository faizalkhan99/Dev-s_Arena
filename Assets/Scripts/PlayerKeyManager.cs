using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyManager : MonoBehaviour
{
    public bool HasKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Key"))
        {
            HasKey = true;
        }
    }
}