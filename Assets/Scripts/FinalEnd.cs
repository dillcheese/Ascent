using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalEnd : MonoBehaviour
{
    //public string victorySceneName; // Name of your victory scene
    [SerializeField ] private Image fadeImage; // The Image component that will be used for the fade effect
    private bool Ended;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Assuming your player object has the tag "Player"
        {
            Ended = true;
            StartCoroutine(FadeToWhiteAndLoadScene());
        }
    }

    private IEnumerator FadeToWhiteAndLoadScene()
    {
        float duration = 2.5f; // Duration of the fade effect
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = currentTime / duration;
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        SceneManager.LoadScene("Victory");
    }


    public bool GetEnded()
    {
        return Ended;
    }
}