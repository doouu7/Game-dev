using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; 
    private float elapsedTime;                           
    private bool isRunning = true;                       

    void Update()
    {
       
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

           
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void StopTimer()
    {
        isRunning = false;
    }
}
// for reference and citation, gen AI was used to help me write in C# language. i didnt know how to write in c.
    //i did write the logic and the code itself
    //written by mana1c22