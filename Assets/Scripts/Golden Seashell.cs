using UnityEngine;

public class GoldenSeashell : MonoBehaviour
{
    [Header("Letter Info")]
    public string letter; // Assign in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           if (GameManager.Instance != null)
            {
                GameManager.Instance.AddSeashell(1); // Adds to the carry-over total
            }
            if (!string.IsNullOrEmpty(letter))
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddLetter(letter);
                    Debug.Log("Collected letter: " + letter);
                }
            }

            Debug.Log("Letters now: " + string.Join(",", GameManager.Instance.collectedLetters));

            // Destroy seashell 
            Destroy(gameObject);
        }
    }
}