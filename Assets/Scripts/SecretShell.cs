using UnityEngine;

public class SecretShell : MonoBehaviour
{
    public int letterIndex;  // which letter this shell reveals
    private SecretWordManager wordManager;

    void Start()
    {
        wordManager = FindObjectOfType<SecretWordManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (wordManager != null)
            {
                wordManager.RevealLetter(letterIndex);
            }
            Destroy(gameObject);
        }
    }
}
