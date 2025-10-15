//[Author: Eyad Al Raeeini]\\
//[ Main Menu ]
//10/14/2025


using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Object sceneToLoad;
    public void PlayGame()
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
        else
        {
            Debug.LogWarning("No scene FOund!");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
