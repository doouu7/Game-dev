using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Timer>().StopTimer();
            Debug.Log("Finish Line Reached! Timer Stopped.");
        }
    }
}
