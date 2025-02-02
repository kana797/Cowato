using UnityEditor.Rendering;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;


public class ClockController : MonoBehaviour
{
    public GameObject clock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartTimer()
    {
        clock.SetActive(true);

    }
}
