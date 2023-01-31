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
    public static bool IsActiveSentences = false;
    public GameObject InteractItem;
    public Button[] buttons;
    public string textSkip;

    void EnableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    void DisableAllButtons()
    {
        foreach (Button button in buttons)
        {
            if (button.name == "NextButton")
                continue;
            button.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        //!!!!!!!!!!!!!!!!!!
        GameEvents.current.DialogEventTrigger(0);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        buttons = FindObjectsOfType<Button>();
        DisableAllButtons();
        InteractItem.SetActive(false);
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
        if (!IsActiveSentences)
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
            textSkip = sentence;
            StopAllCoroutines();
            //остановка вех карутин
            StartCoroutine(TypeSentece(sentence));
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = textSkip;
            IsActiveSentences = false;
        }
    }
    IEnumerator TypeSentece(string sentence)
    {
        IsActiveSentences = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
        IsActiveSentences = false;
    }
    void EndDialogue()
    {
        InteractItem.SetActive(true);
        EnableAllButtons();
        dialogbox.SetActive(false);
    }
    


}
