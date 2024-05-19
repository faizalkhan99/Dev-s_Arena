using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private bool keyRequired;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (keyRequired)
            {
                if (other.GetComponent<PlayerKeyManager>().HasKey)
                {
                    //Do scene transition
                }
            }
            else
            {
                //Do scene Transition
            }
        }
    }
}