// Eyad Al Raeeini
//speed boost timer ui
// [11/12/2025]

using UnityEngine;
using TMPro;
public class SpeedUI : MonoBehaviour
{
    public TextMeshProUGUI boostText;
    private float timeRemaining;
    private bool countingDown = false;

    public void StartBoostTimer(float duration)
    {
        timeRemaining = duration;
        countingDown = true;
        boostText.gameObject.SetActive(true);
    }

    public void HideBoostTimer()
    {
        countingDown = false;
        boostText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (countingDown)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0f)
            {
                HideBoostTimer();
                return;
            }

            int seconds = (int)timeRemaining;
            boostText.text = "Speed Boost: " + seconds + "s";
        }
    }
}