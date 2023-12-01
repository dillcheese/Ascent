using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TextShow : MonoBehaviour
{
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private string fullText;
    private float delay = 0.02f; // Delay in seconds
    [SerializeField] private GameObject player; // Reference to the player object


    private bool hasShown = false; // Track whether the text has been shown

    void Update()
    {
        // Calculate the distance between the player and the text object
        //float distance = Vector2.Distance(player.transform.position, transform.position);

        //// If the player is close enough and the text hasn't been shown, start showing the text
        //if (distance <= triggerDistance && !hasShown)
        //{
        //    StartCoroutine(ShowText());
        //    hasShown = true; // Mark the text as shown
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasShown) // Assuming your player object has the tag "Player"
        {
            StartCoroutine(ShowText());
            hasShown = true; // Mark the text as shown
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            uiText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

}
