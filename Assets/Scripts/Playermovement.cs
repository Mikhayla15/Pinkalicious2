using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; 
    public float jumpHeight = 2f;

    [Header("Score Settings")]
    // Note: We are now using GameManager.Instance.totalSeashells instead of this local one
    public int goldenSeashellsCollected = 0; 
    public TMP_Text scoreText;
    public TMP_Text livesText;

    private Vector3 startPosition;
    private bool isFrozen = false;

    void Start()
    {
        startPosition = transform.position;
        UpdateUI();
    }

    void Update()
    {
        if (!isFrozen)
        {
            MovePlayer();
        }
        
        // We call UpdateUI here to keep the screen refreshed
        UpdateUI();
    }

    void UpdateUI()
    {
        // Check for the score text
        if(scoreText != null && GameManager.Instance != null)
        {
            scoreText.text = "Seashells: " + GameManager.Instance.totalSeashells;
        }

        // Check for the lives text
        if(livesText != null && GameManager.Instance != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.lives;
        }
    }

    void MovePlayer()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;

        transform.position += new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vector3.up * jumpHeight;
        }
    }

    public void ResetToStart()
    {
        transform.position = startPosition;
    }

    public void FreezePlayer(bool freeze)
    {
        isFrozen = freeze;
    }

    public void AddGoldenSeashell(int amount = 1)
    {
        goldenSeashellsCollected += amount;
    }

    public void LoseGoldenSeashells(int amount = 1)
    {
        goldenSeashellsCollected -= amount;
        if (goldenSeashellsCollected < 0)
            goldenSeashellsCollected = 0;
    }
}