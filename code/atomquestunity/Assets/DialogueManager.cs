using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Animator animator;
    public PlayerInteractionManager playerInteraction; // Reference to the PlayerInteraction script

    private Queue<string> sentences;
    private bool isTyping;  // Flag to check if a sentence is currently being typed
    private HashSet<string> displayedSentences; // Keep track of displayed sentences

    void Awake()
    {
        sentences = new Queue<string>();
        displayedSentences = new HashSet<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Lock player input when dialogue starts
        playerInteraction.DisablePlayerInput();

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            // Only enqueue sentences that haven't been displayed yet
            if (!displayedSentences.Contains(sentence))
            {
                sentences.Enqueue(sentence);
                displayedSentences.Add(sentence);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (!isTyping)
        {
            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        // Unlock player input when dialogue ends
        playerInteraction.EnablePlayerInput();

        animator.SetBool("IsOpen", false);
    }
}
