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
    public int maxLives = 5;
    public int totalSeashells = 0;

    [Header("Collected Letters")]
    public List<string> collectedLetters = new List<string>(); 

    [Header("Scene Settings")]
    [Tooltip("Optional: set a scene name to load on game over.")]
    public string gameOverSceneName = "GameOver";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void GainLife(int amount)
    {
       lives = Mathf.Min(lives + amount, maxLives);
    }
    
    public void ResetGame()
    {
        score = 0;
        lives = 3;
        collectedLetters.Clear(); 
        Debug.Log("Game reset.");
    }

    private void GameOver()
    {
        Debug.Log("Game Over! All lives lost.");
        
    }
    #endregion

    #region Letter Tracking
    public void AddLetter(string letter)
    {
        // For a List, we check if it Contains the letter first to avoid duplicates
        if (!collectedLetters.Contains(letter)) 
        {
            collectedLetters.Add(letter);
            Debug.Log("Collected Letters: " + string.Join(",", collectedLetters));
      Object.FindFirstObjectByType<WordDisplay>()?.UpdateDisplay();
        }
    }

    public bool HasLetter(string letter)
    {
        return collectedLetters.Contains(letter);
    }

    public void ResetLetters()
    {
        collectedLetters.Clear();
    }
    public void AddSeashell(int amount)
    {
        totalSeashells += amount;
        Debug.Log("Total Seashells in Backpack: " + totalSeashells);
    }
    #endregion
}