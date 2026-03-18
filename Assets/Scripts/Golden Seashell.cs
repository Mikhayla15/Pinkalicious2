using UnityEngine;

public class GoldenSeashell : MonoBehaviour
{
    [Header("Letter Info")]
    public string letter; // Assign in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add letter if it exists
            if (!string.IsNullOrEmpty(letter))
            {
                GameManager.Instance.AddLetter(letter);
                Debug.Log("Collected letter: " + letter);
            }

            // Add life
            GameManager.Instance.GainLife(1);

            Debug.Log("Letters now: " + string.Join(",", GameManager.Instance.collectedLetters));

            // Destroy seashell so it doesn't trigger again
            Destroy(gameObject);
        }
    }
}
