using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [Header("Seashell Settings")]
    public int seashells = 0;
    public int requiredSeashells = 20;

    [Header("Lives")]
    public int lives = 3;

    [Header("Timer")]
    public float levelTime = 120f; // 2 minutes
    private float currentTime;
    public float moveSpeed = 7f;

    private bool isFrozen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTime = levelTime;
    }
    private float sectionTimer = 0f;
    private void Update()
    {
        RunTimer();
        HandleButterfly();
         CheckGameState();
        sectionTimer += Time.deltaTime;

    if (sectionTimer >= 60f)
    {
        SpawnButterfly();
        sectionTimer = 0f;
    }
    }
    void HandleButterfly()
    {
        sectionTimer += Time.deltaTime;

        if (sectionTimer >= 60f)
        {
            SpawnButterfly();
            sectionTimer = 0f;
        }
    }
    void CheckGameState()
    {
        // Example logic
        if (seashells >= requiredSeashells)
        {
            Debug.Log("Ready to free the mermaid!");
        }
    }

    void RunTimer()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            RestartLevel();
        }
    }

    public void AddSeashells(int amount)
    {
        seashells += amount;

        if (seashells < 0)
        {
            StartCoroutine(FreezePlayer());
        }

        Debug.Log("Seashells: " + seashells);
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            RestartLevel();
        }
    }

    IEnumerator FreezePlayer()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            PlayerMovement.Instance.canMove = false;

            yield return new WaitForSeconds(5f);

            PlayerMovement.Instance.canMove = true;
            isFrozen = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool CanFreeMermaid()
    {
        return seashells >= requiredSeashells;
    }


    void SpawnButterfly()
    {
        Debug.Log("Butterfly appears to guide player!");
    }
}

