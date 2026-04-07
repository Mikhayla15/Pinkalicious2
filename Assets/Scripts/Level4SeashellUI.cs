using UnityEngine;
using TMPro; // This is the key!

public class Level4SeashellUI : MonoBehaviour
{
    
    public TMP_Text seashellText; 

    void Start()
    {
        if (GameManager.Instance != null && seashellText != null)
        {
            seashellText.text = "Seashells: " + GameManager.Instance.totalSeashells;
        }
    }
}