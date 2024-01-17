using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager2 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Animator animator;

    private Queue<string> sentences;
    private bool isTyping;  // Flag to check if a sentence is currently being typed

    // Time to wait before displaying the next sentence (in seconds)
    public float timeBetweenSentences = 2.0f;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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

        // Wait for a specified time before displaying the next sentence
        yield return new WaitForSeconds(timeBetweenSentences);

        isTyping = false;

        // Display the next sentence
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}