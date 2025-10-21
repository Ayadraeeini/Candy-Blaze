//[Aurthor:Eyad Al Raeeini]
//THIS CONTROLS THE PLAYER X AND Y LOOL SENSTIVITY\\
// [10/05/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         transform.Rotate(Vector3.up * mouseX);
    }
}