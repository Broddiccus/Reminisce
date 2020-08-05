using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<string> onDialogueTriggerEvent;
    public void DialogueTriggerEvent(string id)
    {
        if (onDialogueTriggerEvent != null)
        {
            onDialogueTriggerEvent(id);
        }
    }
}
