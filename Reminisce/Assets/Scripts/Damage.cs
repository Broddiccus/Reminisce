using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int health = 1;
    public bool bombOnly = false;
    public string eventId;
    private void Start()
    {
    }
    public void Damager(int x, string dType)
    {
        if (bombOnly && dType == "bomb")
        {
            health -= x;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (!bombOnly)
        {
            health -= x;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (eventId != "")
        {
            EventManager.current.DialogueTriggerEvent(eventId);
        }
    }
}
