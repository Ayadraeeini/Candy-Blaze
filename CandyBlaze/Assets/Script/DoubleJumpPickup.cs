
// [Author: Eyad Al Raeeini]
// this is resposible for double jump ability once the player collect the item this script attahced to //
// Date: 09/30/2025 //


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null) {
            player.UnlockDoubleJump();
            Destroy(gameObject);
        }
    }
}
