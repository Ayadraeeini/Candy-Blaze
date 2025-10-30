//[Aurthor:Eyad Al Raeeini]
//THIS Move an object in ping pong movement with two cordinated points \\
// [10/20/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public Transform pointA;
    public Transform pointB;

    void Update()
    {
        if (pointA == null || pointB == null)
            return;
        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
    }
}
