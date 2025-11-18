//Eyad Al Raeeini]
//speed boost pickup\
// [11/12/2025]
using UnityEngine;
public class SpeedPickup : MonoBehaviour
{
    public float duration = 5f;
    public float multiplier = 1.5f;

void OnTriggerEnter(Collider other)

    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ActivateSpeedBoost(duration, multiplier);
            Destroy(gameObject);
        }
    }
}