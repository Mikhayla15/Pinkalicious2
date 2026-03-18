using UnityEngine;

public class SecretShell : MonoBehaviour
{
    public int letterIndex;  // which letter this shell reveals
    private SecretWordManager wordManager;

    void Start()
    {
        wordManager = Object.FindFirstObjectByType<SecretWordManager>();

        // Hide shell if letter already collected
        if (GameManager.Instance.HasLetter(GetLetterFromIndex(letterIndex)))
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (wordManager != null)
            {
                // 🔥 Reveal letter in the UI (handled by SecretWordManager)
                wordManager.RevealLetter(letterIndex);

                // 🔥 Save the letter in GameManager (so it persists across levels)
                GameManager.Instance.AddLetter(GetLetterFromIndex(letterIndex));
            }

            // Destroy shell so it can't be collected twice
            Destroy(gameObject);
        }
    }

    // Helper function to map the index to the letter
    string GetLetterFromIndex(int index)
    {
        string word = "PEARL"; // SecretWordManager will handle UI, don't try to use secretWord here
        return word[index].ToString();
    }
}