using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private bool keyRequired;
    [SerializeField] private int _buildIndexToLoadNext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (keyRequired)
            {
                if (other.GetComponent<PlayerKeyManager>().HasKey)
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().LoadScene(_buildIndexToLoadNext);
                }
            }

            else
            {
                GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().LoadScene(_buildIndexToLoadNext);
            }
        }
    }
}