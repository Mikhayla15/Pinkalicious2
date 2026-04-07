using UnityEngine;

public class SecretShell : MonoBehaviour
{
    public int letterIndex; 
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
               
                wordManager.RevealLetter(letterIndex);

                GameManager.Instance.AddLetter(GetLetterFromIndex(letterIndex));
            }

            // Destroy shell so it can't be collected twice
            Destroy(gameObject);
        }
    }

    // Helper function to map the index to the letter
    string GetLetterFromIndex(int index)
    {
        string word = "PEARL"; 
        return word[index].ToString();
    }
}