using System.Collections;
using UnityEngine;

public class InitialDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Awake()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        StartCoroutine(DelayedTrigger());
    }

    IEnumerator DelayedTrigger()
    {
        yield return null;
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueManager not found in the scene.");
        }
    }
}