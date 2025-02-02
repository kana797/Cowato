using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class CountdownWithButton2 : MonoBehaviour
{
    public GameObject countdownPanel2; // The object to show (e.g., Panel)
    public TMP_Text timerText2; // The TextMeshPro UI text for the countdown
    public Button startButton2; // The button that starts the countdown
    public float countdownTime2 = 60f; // 1 minute countdown

    private float timeRemaining;
    private bool isCounting = false;

    void Start()
    {
        countdownPanel2.SetActive(false); // Hide the panel at the start
        startButton2.onClick.AddListener(StartCountdown); // Assign button event
    }

    void Update()
    {
        if (isCounting && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText2.text = $"Time: {Mathf.Ceil(timeRemaining)}s"; // Update UI text
        }
        else if (isCounting && timeRemaining <= 0)
        {
            isCounting = false;
            countdownPanel2.SetActive(false); // Hide the panel when time runs out
        }
    }

    public void StartCountdown()
    {
        countdownPanel2.SetActive(true); // Show the panel
        timeRemaining = countdownTime2; // Reset timer to 1 minute
        isCounting = true;
    }
}

