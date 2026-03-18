using UnityEngine;

public class Level2Debug : MonoBehaviour
{
    void Start()
    {
        if(GameManager.Instance != null)
        {
            Debug.Log("Letters from Level 1: " + string.Join(",", GameManager.Instance.collectedLetters));
        }
        else
        {
            Debug.Log("GameManager instance is null!");
        }
    }
}
