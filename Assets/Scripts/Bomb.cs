using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explodeTimimg;
    [SerializeField] private float detectionRange;
    [SerializeField] private float damageRange;
    [SerializeField] private LayerMask playerLayer;

    private bool isDetected;

    private void Update()
    {
        if (!isDetected)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
            if (cols != null && cols.Length > 0)
            {
                foreach (var col in cols)
                {
                    if (col.TryGetComponent<PlayerHealthManager>(out var playerHealth))
                    {
                        isDetected = true;
                        StartCoroutine(StartCountDown(playerHealth));
                        break;
                    }
                }
            }
        }
    }

    private float currentTimer = 0f;

    private IEnumerator StartCountDown(PlayerHealthManager healthManager)
    {
        currentTimer += Time.deltaTime;
        while (currentTimer <= explodeTimimg)
        {
            yield return null;
        }
        Boom(healthManager);
    }

    private void Boom(PlayerHealthManager healthManager)
    {
        healthManager.KillPlayer();
    }
}