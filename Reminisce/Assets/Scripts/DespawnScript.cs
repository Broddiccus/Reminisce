using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    public string eventType;
    private void Start()
    {
        EventManager.current.onDialogueTriggerEvent += DialogueEvent;
    }
    private void DialogueEvent(string id)
    {
        if (id == eventType)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        EventManager.current.onDialogueTriggerEvent -= DialogueEvent;
    }
}
