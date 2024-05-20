using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    [SerializeField] private float range;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BrokenFloor"))
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, range);
            if (cols.Length > 0)
            {
                foreach (var col in cols)
                {
                    if (col.CompareTag("BrokenFloor"))
                    {
                        Rigidbody rb = col.GetComponent<Rigidbody>();
                        rb.isKinematic = false;
                        rb.AddTorque(Random.insideUnitSphere.normalized * Random.Range(5, 10), ForceMode.Force);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}