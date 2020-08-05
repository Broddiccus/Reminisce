using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public string eventType;
    public GameObject spawnPart;
    private void Start()
    {
        spawnPart.SetActive(false);
        EventManager.current.onDialogueTriggerEvent += DialogueEvent;
    }
    private void DialogueEvent(string id)
    {
        if (id == eventType)
        {
            spawnPart.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        EventManager.current.onDialogueTriggerEvent -= DialogueEvent;
    }
}

