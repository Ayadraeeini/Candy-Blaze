//[Aurthor:Eyad Al Raeeini]
//THIS Move an object in ping pong movement with two cordinated points \\
// [10/20/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private float timeCounter = 0f;
    public Transform pointA;
    public Transform pointB;

    void Update()
    {
        if (pointA == null || pointB == null) return;
        timeCounter += Time.deltaTime * speed;
       float t = (Mathf.Sin(timeCounter) + 1f) / 2f;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
    }
}
