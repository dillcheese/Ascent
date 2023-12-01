using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTimes : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        // Load the current time and best time from PlayerPrefs
        float currentTime = PlayerPrefs.GetFloat("EndTime", 0);
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);

        // Display the current time and best time
        currentTimeText.text = "Current Time: " + currentTime.ToString("F2");
        bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
    }
}