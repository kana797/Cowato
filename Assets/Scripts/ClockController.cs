using UnityEditor.Rendering;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;


public class ClockController : MonoBehaviour
{
    public GameObject clock;
    public GameObject timePanel;
    private TMP_Text buttonText;
    private float time = 60f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartTimer()
    {
        clock.SetActive(true);
        timePanel.SetActive(true);
        buttonText = clock.GetComponentInChildren<TMP_Text>();
    }
}
