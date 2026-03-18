
using UnityEngine;
using TMPro; // Make sure you are using TextMeshPro if using TMP_Text

public class WordDisplay : MonoBehaviour
{
    public TMP_Text displayText; // Assign in Inspector (your top UI element)

    void Start()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (GameManager.Instance != null)
        {
            // Build a string like: A - - C - - if letters are collected
            // Assuming you know the word length, e.g., 6 letters
            int wordLength = 6; 
            string display = "";

            for (int i = 0; i < wordLength; i++)
            {
                // Replace dash with collected letter if it exists
                // This example just shows letters in order they were collected
                if (i < GameManager.Instance.collectedLetters.Count)
                {
                    string[] letters = new string[GameManager.Instance.collectedLetters.Count];
                    GameManager.Instance.collectedLetters.CopyTo(letters);
                    display += letters[i];
                }
                else
                {
                    display += "-";
                }

                if (i < wordLength - 1)
                    display += " "; // space between letters
            }

            displayText.text = display;
        }
    }
}