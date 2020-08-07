using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public string eventType;
    public GameObject[] spawnPart;
    private void Start()
    {
        foreach (GameObject x in spawnPart)
        {
            x.SetActive(false);
        }
        
        EventManager.current.onDialogueTriggerEvent += DialogueEvent;
    }
    private void DialogueEvent(string id)
    {
        if (id == eventType)
        {
            foreach (GameObject x in spawnPart)
            {
                x.SetActive(true);
            }
        }
    }
    private void OnDestroy()
    {
        EventManager.current.onDialogueTriggerEvent -= DialogueEvent;
    }
}

