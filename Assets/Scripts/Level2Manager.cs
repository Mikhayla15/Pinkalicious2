using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    void Start()
    {
        foreach (string letter in GameManager.Instance.collectedLetters)
        {
            Debug.Log("Carried from Level 1: " + letter);
        }

        // Example: unlock letters in Level 2 puzzle/UI
    }
}