//[Aurthor:Eyad Al Raeeini]
//this script responsible for respawing the player when they die\\
// [10/20/2025]

using UnityEngine;


public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (spawnPoint == null)
        {
            Debug.LogWarning("Spawn point is not aasigned.");
        }
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
       transform.position = spawnPoint.position;
       transform.rotation = spawnPoint.rotation;
        Debug.Log("Player respawned!");
    }
}
