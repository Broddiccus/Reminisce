using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;
    public bool oneTime = false;
    public bool Examine = true;
    public bool Active = true;
    public void TriggerDialogue()
    {
        if (Active)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Variables.Object(GameObject.Find("Player")).Set("IsTalking", true);
            if (oneTime)
                Destroy(gameObject);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!Examine)
        {
            if (other.tag == "Player")
            {
                TriggerDialogue();
                if (oneTime)
                    Destroy(gameObject);
            }
        }
        
    }
    
}
