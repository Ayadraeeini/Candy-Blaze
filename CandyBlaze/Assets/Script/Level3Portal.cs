//Eyad Al Raeeini - 11/13/2025
//portal to level 3
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level3Portal : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            SceneManager.LoadScene("Level3");
        }
    }
}