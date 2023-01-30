using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> names;

    public GameObject dialogbox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public static bool isActiveSentences;
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        //!!!!!!!!!!!!!!!!!!
        GameEvents.current.DialogEventTrigger(0);
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
        isActiveSentences = false;
        if (sentences.Count == 0)
        {
            isActiveSentences = true;
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.text = name;
        dialogueText.text = sentence;
        StopAllCoroutines();
       //остановка вех карутин
        StartCoroutine(TypeSentece(sentence));
    }
    IEnumerator TypeSentece(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return  new WaitForSeconds(.05f);
        }
    }
    void EndDialogue()
    {
        dialogbox.SetActive(false);
    }
    


}
