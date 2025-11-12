using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the TMP text
    private float elapsedTime;                           // Time counter

    void Update()
    {
        // Increase time as the game runs
        elapsedTime += Time.deltaTime;

        // Format as minutes:seconds (e.g., 01:23)
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Display formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
