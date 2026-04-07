using UnityEngine;
using TMPro;

public class Level4LivesUI : MonoBehaviour
{
    public TMP_Text livesText; 

    void Start()
    {
        if (GameManager.Instance != null && livesText != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.lives;
        }
    }
}