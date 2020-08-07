using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bolt;

public class DialogueManager : MonoBehaviour
{
    private string eventId;
    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<Sprite> portraits;
    public Animator popUp;
    public Text nameUI;
    public Text sentenceUI;
    public Image portraitUI;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.onDialogueTriggerEvent += DialogueEvent;
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        names = new Queue<string>();
    }
    private void DialogueEvent(string id)
    {
        if (id == "bomb")
        {
            Variables.Object(GameObject.Find("Player")).Set("CanBomb", true);
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        popUp.SetBool("Talking", true);
        sentences.Clear();
        portraits.Clear();
        names.Clear();
        eventId = dialogue.EventId;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        foreach (Sprite portrait in dialogue.portraits)
        {
            portraits.Enqueue(portrait);
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
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        Sprite portrait = portraits.Dequeue();

        nameUI.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        portraitUI.sprite = portrait;
    }
    IEnumerator TypeSentence (string sentence)
    {
        sentenceUI.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentenceUI.text += letter;
            yield return null;
        }
    }
    
    void EndDialogue()
    {
        Variables.Object(GameObject.Find("Player")).Set("IsTalking", false);
        popUp.SetBool("Talking", false);
        if (eventId != "")
        {
            EventManager.current.DialogueTriggerEvent(eventId);
        }
        //end dialogue
    }
    private void OnDestroy()
    {
        EventManager.current.onDialogueTriggerEvent -= DialogueEvent;
    }

}
