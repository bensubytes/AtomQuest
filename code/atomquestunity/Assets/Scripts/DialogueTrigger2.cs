using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
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
        FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);
    }
}