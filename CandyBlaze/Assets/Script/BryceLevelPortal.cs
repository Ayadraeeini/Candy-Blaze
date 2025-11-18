using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BryceLevelPortal : MonoBehaviour
{
    public int LevelIndexToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelIndexToLoad);
        }
    }
}
