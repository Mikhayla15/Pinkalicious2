using UnityEngine;
using TMPro;

public class PirateDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;  // drag DialogueText here
    public GameObject dialogueBox; // drag DialogueBox here

    void Start()
    {
        dialogueBox.SetActive(true);

        dialogueText.text = "Ahoy Pinkalicious! I have captured your mermaid friend! " +
                            "If you want to save her, you must collect 15 golden seashells " +
                            "and find the hidden letters to reveal the secret password!";

        Invoke("HidePirate", 8f); // pirate disappears after 8 seconds
    }

    void HidePirate()
    {
        dialogueBox.SetActive(false);
        gameObject.SetActive(false); // pirate disappears
    }
}