//Eyad Al Raeeini - 11/12/2025
//makes platform go in circles vertically

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwingPlatform360 : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 3f;
    public float speed = 50f;
    float angle = 0f;

    void Update()
    {
        if (centerPoint == null)
            return;

        angle += speed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * radius;
        float y = Mathf.Sin(rad) * radius;

        transform.position = centerPoint.position + new Vector3(x, y, 0);
    }
}