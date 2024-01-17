using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        Debug.Log("DialogueTrigger.Start()");
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        Debug.Log("DialogueTrigger.TriggerDialogue()");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
