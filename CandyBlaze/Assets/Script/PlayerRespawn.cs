//[Aurthor:Eyad Al Raeeini]
//respawns player when they die\
// [10/20/2025]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerRespawn : MonoBehaviour
{
    public Transform initialSpawnPoint;
    private Transform currentCheckpoint;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (initialSpawnPoint != null)
          currentCheckpoint = initialSpawnPoint;
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (currentCheckpoint != null)
        {
             transform.position = currentCheckpoint.position;
            transform.rotation = currentCheckpoint.rotation;
        }
    }

    public void UpdateCheckpoint(Transform newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }
}