using UnityEngine;
using TMPro; // Only if using TextMeshPro, otherwise use UnityEngine.UI

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText; // Drag your GameOverText here
    private bool gameOverShown = false;

    void Update()
    {
        if (!gameOverShown && GameManager.Instance.lives <= 0)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        gameOverShown = true;

        // Optional: stop player movement, pause game, etc.
        Time.timeScale = 0f; // pause game
    }

    // Optional: restart level
    public void RestartLevel()
    {
        Time.timeScale = 1f; // unpause
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}