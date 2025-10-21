//[Aurthor:Eyad Al Raeeini]
//THIS Add Time when player collect the item\\
// [10/20/2025]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeOnCollect : MonoBehaviour
{
    [Tooltip("How many seconds does this item add")]
    public float timeToAdd = 10f;
     private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
          LevelTimer timer = FindObjectOfType<LevelTimer>();
            if (timer != null)
            {
                timer.AddTime(timeToAdd);
                Debug.Log("Added " + timeToAdd + " seconds!");
            }
           Destroy(gameObject);
        }
    }
}
