//[Aurthor:Eyad Al Raeeini]
//THIS Add Time when player collect the item\\
// [10/20/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeOnCollect : MonoBehaviour
{
    public float timeToAdd = 10f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelTimer timer = FindObjectOfType<LevelTimer>();
            timer.AddTime(timeToAdd);
             Destroy(gameObject);
        }
    }
}
