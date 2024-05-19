using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent<PlayerHealthManager>(out var playerHealth))
            {
                playerHealth.KillPlayer();
            }
        }
    }
}