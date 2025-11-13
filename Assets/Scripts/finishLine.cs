using UnityEngine;
using UnityEngine.SceneManagement;  

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject wellDoneText; 
    [SerializeField] private float returnDelay = 2f;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            FindObjectOfType<Timer>().StopTimer();

            
            if (wellDoneText != null)
                wellDoneText.SetActive(true);

            Debug.Log("Finish Line Reached! Timer stopped and WELL DONE text displayed.");
            Invoke("ReturnToMenu", returnDelay);
        }
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene("menu scene"); 
    }
}

// for reference and citation, gen AI was used to help me write in C# language. i didnt know how to write in c.
    //i did write the logic and the code itself
    //written by mana1c22