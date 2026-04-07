
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
            string display = ""; // This is the variable the warning is talking about

            for (int i = 0; i < wordLength; i++)
            {
                if (i < GameManager.Instance.collectedLetters.Count)
                {
                    display += GameManager.Instance.collectedLetters[i];
                }
                else
                {
                    display += "-";
                }

                if (i < wordLength - 1)
                    display += " "; 
            }
            displayText.text = display; 
            

            Debug.Log("UI Updated: " + display);
        }
    }
}