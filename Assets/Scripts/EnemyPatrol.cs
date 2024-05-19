using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float minWaitTime, maxWaitTime;
    private int nextIndex;

    // Start is called before the first frame update
    private void Start()
    {
        if (patrolPoints.Length != 0)
        {
            transform.position = patrolPoints[0].position;
            nextIndex = 1;
        }
        else
        {
            Debug.LogWarning("Patrol points are empty", this);
        }
        StartPatrol();
    }

    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        if (cols != null && cols.Length > 0)
        {
            foreach (var col in cols)
            {
                if (col.TryGetComponent<PlayerHealthManager>(out var playerHealth))
                {
                    playerHealth.KillPlayer();
                    break;
                }
            }
        }
    }

    private void StartPatrol()
    {
        float time = (patrolPoints[nextIndex].position - transform.position).magnitude / speed;
        LeanTween.move(gameObject, patrolPoints[nextIndex], time).setOnComplete(() =>
        {
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            nextIndex++;
            if (nextIndex > patrolPoints.Length - 1)
            {
                nextIndex = 0;
            }
            LeanTween.delayedCall(waitTime, () =>
            {
                StartPatrol();
            });
        });
    }
}