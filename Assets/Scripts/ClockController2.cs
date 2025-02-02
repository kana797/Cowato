using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class CountdownWithButton2 : MonoBehaviour
{
    public GameObject countdownPanel2; // The object to show (e.g., Panel)
    public TMP_Text timerText2; // The TextMeshPro UI text for the countdown
    public float countdownTime2 = 120f; // 1 minute countdown

    private float timeRemaining2;
    private bool isCounting2 = false;


    void Update()
    {
        if (isCounting2 && timeRemaining2 > 0)
        {
            timeRemaining2 -= Time.deltaTime;
            timerText2.text = $"Time: {Mathf.Ceil(timeRemaining2)}s"; // Update UI text
        }
        else if (isCounting2 && timeRemaining2 <= 0)
        {
            isCounting2 = false;
            countdownPanel2.SetActive(false); // Hide the panel when time runs out
        }
    }

    public void StartCountdown2()
    {
        countdownPanel2.SetActive(true); // Show the panel
        timeRemaining2 = countdownTime2; // Reset timer to 1 minute
        isCounting2 = true;
    }
}

