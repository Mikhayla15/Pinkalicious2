using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinManager : MonoBehaviour
{
    public TMP_Text pirateMessageText; 
    public int shellsRequired = 10;
    public int lettersRequired = 5;

    private bool isProcessing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isProcessing)
        {
            CheckQuestStatus();
        }
    }

    void CheckQuestStatus()
{
    int currentShells = GameManager.Instance.totalSeashells;
    
    // This counts only ACTUAL letters, ignoring empty spaces or dashes
    int currentLetters = 0;
    foreach (string letter in GameManager.Instance.collectedLetters)
    {
        if (!string.IsNullOrEmpty(letter) && letter.Length == 1 && letter != "-")
        {
            currentLetters++;
        }
    }

    Debug.Log($"PIRATE LOG: I see {currentShells} shells and {currentLetters} real letters.");
    if (currentShells >= 10 && currentLetters >= 5) 
    {
        StartCoroutine(HandleWin());
    }
    else
    {
        StartCoroutine(HandleFail());
    }
}
    IEnumerator HandleWin()
{
    if (isProcessing) yield break;
    isProcessing = true; 

    Debug.Log("VICTORY! Condition Met.");

    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if(player != null)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero; 
        rb.simulated = false; //
    }

    // 2. Show the Win Text
    pirateMessageText.text = "YOU WIN! YOUR FRIEND IS FREE!";
    pirateMessageText.gameObject.SetActive(true);

    yield return new WaitForSeconds(5f);
    GameManager.Instance.ResetGame(); 
    SceneManager.LoadScene("startscene");
}

    IEnumerator HandleFail()
    {
        isProcessing = true;
        pirateMessageText.text = "NOT quite... try again!";
        pirateMessageText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3f);

        // Reset the game data so they start fresh
        GameManager.Instance.ResetGame(); 
        
        // Send them back to level 1
        string targetScene = "level1"; 

        Debug.Log("Attempting to load: " + targetScene);
        GameManager.Instance.ResetGame(); 
        SceneManager.LoadScene("level1");
    }
}