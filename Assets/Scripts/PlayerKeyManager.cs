using UnityEngine;

public class PlayerKeyManager : MonoBehaviour
{
    public bool HasKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Key"))
        {
            HasKey = true;
            collision.gameObject.SetActive(false);
        }
    }
}