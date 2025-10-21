//[Aurthor:Eyad Al Raeeini]
//Controls the main menu\\
// [10/05/2025]

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header(" level scene to load")]
    public string levelToLoad;
    public void StartGame()
    {
        if (string.IsNullOrEmpty(levelToLoad))
        {
           Debug.LogWarning("No level name set in the inspector!");
            return;
        }
        SceneManager.LoadScene(levelToLoad);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
