//[Aurthor:Eyad Al Raeeini]
//teleports player to next level\
// [10/30/2025]
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelPortal : MonoBehaviour
{
    public string sceneToLoad;
    public float delayBeforeLoad = 0f;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
          StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        if (delayBeforeLoad > 0)
            yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}