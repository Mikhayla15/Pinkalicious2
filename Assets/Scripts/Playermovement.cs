using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; 
    public float jumpHeight = 2f;

    [Header("Score Settings")]
    public int goldenSeashellsCollected = 0;
    public TMP_Text scoreText;

    private Vector3 startPosition;
    private bool isFrozen = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isFrozen)
        {
            MovePlayer();
        }

        if(scoreText != null)
        {
            scoreText.text = "Seashells: " + goldenSeashellsCollected;
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

    // Freeze Pinkalicious temporarily (Red Seashell)
    public void FreezePlayer(bool freeze)
    {
        isFrozen = freeze;
    }

    // Add seashells (Golden Seashell)
    public void AddGoldenSeashell(int amount = 1)
    {
        goldenSeashellsCollected += amount;
    }

    // Remove seashells (Red Seashell)
    public void LoseGoldenSeashells(int amount = 1)
    {
        goldenSeashellsCollected -= amount;
        if (goldenSeashellsCollected < 0)
            goldenSeashellsCollected = 0;
    }
}