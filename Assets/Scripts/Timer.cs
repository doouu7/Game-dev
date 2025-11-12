using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the TMP text
    private float elapsedTime;                           // Time counter
    private bool isRunning = true;                       // Controls whether the timer runs

    void Update()
    {
        // Only count time while running
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            // Format as minutes:seconds (e.g., 01:23)
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            // Display formatted time
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // 🔹 Method that can be called from other scripts to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }
}
