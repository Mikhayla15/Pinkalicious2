using UnityEngine;
using TMPro;

public class SecretWordManager : MonoBehaviour
{
    public TMP_Text wordText;

    string secretWord = "PEARL";
    char[] revealedLetters;

    void Awake() // 🔥 runs BEFORE Start
    {
        revealedLetters = new char[secretWord.Length];

        for (int i = 0; i < revealedLetters.Length; i++)
        {
            revealedLetters[i] = '_';
        }
    }

    void Start()
    {
        UpdateWordDisplay();
    }

    public void RevealLetter(int index)
    {
        if (revealedLetters == null)
        {
            Debug.LogError("revealedLetters is NULL!");
            return;
        }

        if (index < 0 || index >= secretWord.Length) return;

        revealedLetters[index] = secretWord[index];
        UpdateWordDisplay();
    }

    void UpdateWordDisplay()
    {
        if (wordText == null)
        {
            Debug.LogError("wordText is NOT assigned!");
            return;
        }

        if (revealedLetters == null)
        {
            Debug.LogError("revealedLetters is NULL in Update!");
            return;
        }

        wordText.text = string.Join(" ", revealedLetters);
    }
}