using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public bool IsDead;

    public void KillPlayer()
    {
        IsDead = true;
        //Play death animation etc..
    }
}