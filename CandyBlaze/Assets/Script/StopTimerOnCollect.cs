//[Aurthor:Eyad Al Raeeini]
//resets the timer when player collects it\
// [10/22/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimerOnCollect : MonoBehaviour
{
    public LevelTimer levelTimer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelTimer.ResetTimer();
            Destroy(gameObject);
        }
    }
}