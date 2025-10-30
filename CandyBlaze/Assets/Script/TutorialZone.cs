//[Aurthor:Eyad Al Raeeini]
//shows tutorial text when player enters trigger\
// [10/29/2025]

using System.Collections;
using UnityEngine;
using TMPro;
public class TutorialTrigger : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string message = "Use WASD to move, Space to jump!";
    private bool hasTriggered = false;
    public float displayTime = 4f;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))  {
            hasTriggered = true;
            tutorialText.text = message;
            tutorialText.gameObject.SetActive(true);
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(displayTime);
        tutorialText.gameObject.SetActive(false);
    }
}