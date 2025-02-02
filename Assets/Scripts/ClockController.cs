using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class CountdownWithButton : MonoBehaviour
{
    public GameObject countdownPanel; // The object to show (e.g., Panel)
    public TMP_Text timerText; // The TextMeshPro UI text for the countdown
    public float countdownTime = 60f; // 1 minute countdown
    public float countdownTime2 = 120f;
    private float timeRemaining;
    private bool isCounting = false;


    void Update()
    {
        if (isCounting && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.Ceil(timeRemaining)}s"; // Update UI text
        }
        else if (isCounting && timeRemaining <= 0)
        {
            isCounting = false;
            countdownPanel.SetActive(false); // Hide the panel when time runs out
        }
    }

    public void StartCountdown()
    {
        countdownPanel.SetActive(true); // Show the panel
        timeRemaining = countdownTime; // Reset timer to 1 minute
        isCounting = true;
    }

    public void StartCountdown2()
    {
        countdownPanel.SetActive(true); // Show the panel
        timeRemaining = countdownTime2; // Reset timer to 1 minute
        isCounting = true;
    }
}
