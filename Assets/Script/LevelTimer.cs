//[Aurthor:Eyad Al Raeeini]
//THIS is responsible for the level timer in the level\\
// [10/21/2025]

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public Slider timeBar;
    public float startTime = 180f; // 3 minutes
    private float currentTime;
    private bool isRunning = true;
    public TextMeshProUGUI timeText;

    void Start()
    {
        currentTime = startTime;
        timeBar.maxValue = startTime;
        timeBar.value = startTime;
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                 isRunning = false;
                OnTimeOut();
            }
            timeBar.value = currentTime;
            int minutes = Mathf.FloorToInt(currentTime / 60);
             int seconds = Mathf.FloorToInt(currentTime % 60);
             timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void StopTimer()
    {
        isRunning = false;
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        if (currentTime > startTime)
          currentTime = startTime;
        timeBar.value = currentTime;
        Debug.Log("Added " + amount + " seconds!");
    }
    void OnTimeOut()
    {
        Debug.Log("the time is up! restarting level...");
        Invoke(nameof(RestartLevel), 1.5f);
    }

    void RestartLevel()
    {
        currentTime = startTime;
        isRunning = true;
        timeBar.value = startTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
