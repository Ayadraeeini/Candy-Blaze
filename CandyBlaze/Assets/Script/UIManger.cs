// [Author: Eyad Al Raeeini]
// this is resposible for double jump UI //
// Date: 09/30/2025 //

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI doubleJumpText;

    void Start()
    {
     if (doubleJumpText != null)
     doubleJumpText.gameObject.SetActive(false);
    }

    public void ShowDoubleJumpMessage()
    {
     StartCoroutine(ShowMessage());
    }

    private System.Collections.IEnumerator ShowMessage() {
        doubleJumpText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); 
        doubleJumpText.gameObject.SetActive(false);
    }
}
