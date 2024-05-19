using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtons : MonoBehaviour
{
    [SerializeField] private GameObject _btn;

    private void Start()
    {
        _btn.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _btn.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _btn.SetActive(false);
        }
    }
}
