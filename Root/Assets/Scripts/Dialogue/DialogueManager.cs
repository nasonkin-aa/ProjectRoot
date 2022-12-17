using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> names;

    public GameObject dialogbox;
    public Text nameText;
    public Text dialogueText;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        GameEvents.current.DialogEventTrigger();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogbox.SetActive(true);
        sentences.Clear();
        names.Clear();
   
        NextDialogue(dialogue.names, names);
        NextDialogue(dialogue.sentences, sentences);
        DisplayNextSentence();
    }
    void NextDialogue(string[] Dialogue, Queue<string> SentencesOrName)
    {
        foreach (string i in Dialogue)
        {
            SentencesOrName.Enqueue(i);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.text = name;
        dialogueText.text = sentence;
        StopCoroutine(TypeSentece(sentence));
        StartCoroutine(TypeSentece(sentence));
    }
    IEnumerator TypeSentece(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        dialogbox.SetActive(false);
    }
    


}
