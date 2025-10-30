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
    public float startTime = 180f; //3 minutes
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
            int minutes = (int)(currentTime / 60);
            int seconds = (int)(currentTime % 60);
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        if (currentTime > startTime)
            currentTime = startTime;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTimeOut()
    {
        Invoke("RestartLevel", 1.5f);
    }
}