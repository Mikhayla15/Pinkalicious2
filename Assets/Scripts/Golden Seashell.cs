using UnityEngine;

public class GoldenSeashell : MonoBehaviour
{
    [Header("Letter Info")]
    public string letter; // Assign this in the Inspector, e.g., "A", "B", "C"

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tell the PlayerMovement script (if needed)
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.AddGoldenSeashell();
            }

            // Save the letter to the persistent GameManager
            if (!string.IsNullOrEmpty(letter))
            {
                GameManager.Instance.AddLetter(letter);
            }

            // Destroy the seashell after collecting
            Destroy(gameObject);
        }
    }
}