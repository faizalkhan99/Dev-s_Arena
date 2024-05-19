using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelFiller : MonoBehaviour
{
    [SerializeField] private float fillingMultiplir;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent<PlayerMovemnt>(out var movemnt))
            {
                movemnt.FillFuel(fillingMultiplir);
            }
        }
    }
}