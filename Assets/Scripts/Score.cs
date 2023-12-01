using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;

    private float startTime;
    private float bestTime;//players best
    private float endTime; //time at end of run
                           //    private string filePath;

    [SerializeField] private GameObject end;

    private void Start()
    {
        // Load the best time from PlayerPrefs
        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        // Start the timer
        startTime = Time.time;

        if (bestTime == float.MaxValue)
        {
            // Display the best time
            bestTimeText.text = "Best Time: ";
        }
        else
        {
            // Display the best time
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;

        // If the player has not reached the end of the level
        if (end.GetComponent<FinalEnd>().GetEnded() == false)
        {
            // Display the current time
            timerText.text = "Time: " + currentTime.ToString("F2");
            endTime = currentTime;
        }

        // If the player has reached the end of the level
        if (end.GetComponent<FinalEnd>().GetEnded())
        {
            // Save the run's time to PlayerPrefs
            PlayerPrefs.SetFloat("EndTime", endTime);
            // If the current time is better than the best time
            if (currentTime < bestTime)
            {
                bestTime = currentTime;

                // Save the new best time to PlayerPrefs
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();

                // Update the best time
                bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
            }
        }
    }
}