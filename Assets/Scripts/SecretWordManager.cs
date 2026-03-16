using UnityEngine;
using TMPro;

public class SecretWordManager : MonoBehaviour
{
    public TMP_Text wordText;

    string secretWord = "PEARL";
    char[] revealedLetters;

    void Start()
    {
        revealedLetters = new char[secretWord.Length];

        for (int i = 0; i < revealedLetters.Length; i++)
        {
            revealedLetters[i] = '_';
        }

        UpdateWordDisplay();
    }
      public void RevealLetter(int index)
    {
        revealedLetters[index] = secretWord[index];
        UpdateWordDisplay();
    }

    void UpdateWordDisplay()
    {
        wordText.text = string.Join(" ", revealedLetters);
    }
}
