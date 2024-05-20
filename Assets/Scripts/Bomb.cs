using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explodeTimimg;
    [SerializeField] private float detectionRange;
    [SerializeField] private float damageRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private ParticleSystem particle;
    private GameObject circle;
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
                        circle = transform.GetChild(0).gameObject;
                        LeanTween.scale(circle, new Vector3(damageRange * 2, damageRange * 2, damageRange * 2), explodeTimimg).setOnComplete(() =>
                        {
                            Boom(playerHealth);
                        });
                        break;
                    }
                    else
                    {
                        isDetected = false;
                    }
                }
            }
            else
            {
                isDetected = false;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, damageRange);
    }

    private void Boom(PlayerHealthManager healthManager)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if (cols != null && cols.Length > 0)
        {
            foreach (var col in cols)
            {
                if (col.TryGetComponent<PlayerHealthManager>(out var playerHealth))
                {
                    healthManager.KillPlayer();
                }
            }
        }
        if (!particle.isPlaying)
        {
            particle.Play();
        }
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }
}