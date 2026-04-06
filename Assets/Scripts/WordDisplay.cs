
using UnityEngine;
using TMPro; // Make sure you are using TextMeshPro if using TMP_Text

public class WordDisplay : MonoBehaviour
{
    public TMP_Text displayText; // Assign in Inspector (your top UI element)
    public int wordLength = 5;
    void Start()
    {
       Invoke("UpdateDisplay", 0.1f);
    }

    public void UpdateDisplay()
    {
        if (GameManager.Instance != null && displayText != null)
        {
            // Build a string like: A - - C - - if letters are collected
            // Assuming you know the word length, e.g., 6 letters
            string display = "";

            for (int i = 0; i < wordLength; i++)
            {
                // Replace dash with collected letter if it exists
                // This example just shows letters in order they were collected
                if (i < GameManager.Instance.collectedLetters.Count)
                {
                    display += GameManager.Instance.collectedLetters[i];
                }
                else
                {
                    display += "-";
                }

                if (i < wordLength - 1)
                    display += " "; // space between letters
            }

            displayText.text = display;
            Debug.Log("UI Updated in new scene: " + display);
        }
    }
}