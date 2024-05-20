using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public bool IsDead;
    public GameObject deadScreen;

    public void KillPlayer()
    {
        IsDead = true;
        deadScreen.SetActive(true);
        GetComponent<PlayerMovemnt>().enabled = false;
        //Play death animation etc..
    }
}