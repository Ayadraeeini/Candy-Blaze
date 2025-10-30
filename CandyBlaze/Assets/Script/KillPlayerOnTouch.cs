//[Aurthor:Eyad Al Raeeini]
//This script can be attached to anything to kill the player on Contact\
// [10/05/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          Debug.Log("Player die");
           PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
           
        }
    }
}
