using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText; 
    public float waitTime = 5f; // Increased from 3 to 5 seconds
    private bool gameOverTriggered = false;

    void Update()
    {
        if (!gameOverTriggered && GameManager.Instance != null && GameManager.Instance.lives <= 0)
        {
            StartCoroutine(HandleGameOver());
        }
    }

    IEnumerator HandleGameOver()
    {
        gameOverTriggered = true;

        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER\nReturning to Level 1...";
            gameOverText.gameObject.SetActive(true);
        }

        // Freeze the world
        Time.timeScale = 0f; 

        // Wait a bit longer so the player can process what happened
        yield return new WaitForSecondsRealtime(waitTime);

        // --- THE BIG RESET ---
        Time.timeScale = 1f; 
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.lives = 3;
            GameManager.Instance.totalSeashells = 0;
            // This is the missing piece to make it "Universal"
            GameManager.Instance.collectedLetters.Clear(); 
        }

        // Go back to the very start
        SceneManager.LoadScene("level1");
    }
}