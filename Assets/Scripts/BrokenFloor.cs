using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    private List<Rigidbody> brokenFloorRb;

    // Start is called before the first frame update
    private void Start()
    {
        brokenFloorRb = new List<Rigidbody>();
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            brokenFloorRb.Add(rb);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (var rb in brokenFloorRb)
            {
                rb.isKinematic = false;
                rb.AddTorque(Random.onUnitSphere.normalized * Random.Range(5, 10), ForceMode.Force);
            }
            GetComponent<Collider>().enabled = false;
        }
    }
}