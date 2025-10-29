// [Author: Eyad Al Raeeini]
// This script marks a checkpoint for the player to respawn from \\
// [10/20/2025]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn != null) {
            playerRespawn.UpdateCheckpoint(transform);
        }
    }
}
