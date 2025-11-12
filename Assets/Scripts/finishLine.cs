using UnityEngine;
using TMPro; // required if you're using TextMeshPro UI

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject wellDoneText; // drag the text UI object here in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            FindObjectOfType<Timer>().StopTimer();

            // Show the "WELL DONE!" text
            if (wellDoneText != null)
                wellDoneText.SetActive(true);

            Debug.Log("Finish Line Reached! Timer stopped and WELL DONE text displayed.");
        }
    }
}

// for reference and citation, gen AI was used to help me write in C# language. written by me
