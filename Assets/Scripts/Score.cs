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
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;


        // If the player has not reached the end of the level
        if (end.GetComponent<FinalEnd>().GetEnded() == false)
        {
            endTime = currentTime;
            // Display the current time
            timerText.text = "Time: " + currentTime.ToString("F2");
        }

        // If the player has reached the end of the level
        if (end.GetComponent<FinalEnd>().GetEnded())
        {
            // If the current time is better than the best time
            if (currentTime < bestTime)
            {
                bestTime = currentTime;

                // Save the new best time to the file
                File.WriteAllText(filePath, bestTime.ToString());
            }

            // Display the best time
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
    }
}