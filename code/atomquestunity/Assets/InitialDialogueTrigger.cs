using System.Collections;
using UnityEngine;

public class InitialDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    // Change Start to Awake
    void Awake()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        // Delay the execution by one frame to ensure that DialogueManager is initialized
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