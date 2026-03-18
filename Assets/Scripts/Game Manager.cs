using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Singleton GameManager that persists across scenes and tracks score, lives, and collected letters.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public int score = 0;
    public int lives = 3;

    [Header("Collected Letters")]
    [Tooltip("Letters collected by the player across levels.")]
    public HashSet<string> collectedLetters = new HashSet<string>();

    [Header("Scene Settings")]
    [Tooltip("Optional: set a scene name to load on game over.")]
    public string gameOverSceneName = "GameOver";

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #region Score & Lives
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }

    public void LoseLife(int amount = 1)
    {
        lives -= amount;
        Debug.Log($"Lives: {lives}");

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void ResetGame()
    {
        score = 0;
        lives = 3;
        collectedLetters.Clear(); // Reset letters too
        Debug.Log("Game reset.");
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
    #endregion

    #region Letter Tracking
    /// <summary>
    /// Adds a letter to the player's collected letters.
    /// </summary>
    public void AddLetter(string letter)
    {
        if (collectedLetters.Add(letter)) // Adds only if not already collected
        {
            Debug.Log("Collected Letters: " + string.Join(",", collectedLetters));
        }
    }

    /// <summary>
    /// Check if a specific letter has already been collected.
    /// </summary>
    public bool HasLetter(string letter)
    {
        return collectedLetters.Contains(letter);
    }

    /// <summary>
    /// Reset letters (if you want to start a new word/level sequence)
    /// </summary>
    public void ResetLetters()
    {
        collectedLetters.Clear();
    }
    #endregion
}
