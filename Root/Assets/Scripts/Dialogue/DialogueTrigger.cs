using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool IsEnd;

    public int Id;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, IsEnd);
    }
    private void Start()
    {
        GameEvents.current.onDialogEventTrigger += DialogEventTrigger;
    }
    private void DialogEventTrigger(int id)
    {
        if (id == Id)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, IsEnd);
        }
    }
}
