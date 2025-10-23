//[Aurthor:Eyad Al Raeeini]
//THIS STOP TIMER WHEN PLAYER COLLIDE WITH IT\\
// [10/20/2025]

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
           levelTimer.StopTimer();
             Destroy(gameObject);
        }
    }
}
