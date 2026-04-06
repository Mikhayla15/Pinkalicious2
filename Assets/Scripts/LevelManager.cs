using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            SceneManager.LoadScene("level1"); // Replace "Level2" with your next scene name
        }
    }
}
