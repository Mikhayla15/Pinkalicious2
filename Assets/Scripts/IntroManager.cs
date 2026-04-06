using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("level1"); // your level 1 scene name
        }
    }

    private void Awake()
    {
        // Singleton pattern to keep this object alive across scenes
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

    // Call this from your "Start" button
    public void StartGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void LoadCustomScene(string level1)
    {
        SceneManager.LoadScene(level1);
    }
}
