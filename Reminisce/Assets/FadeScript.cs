using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image fader;
    public float dir = 0;
    public int direction = 0;
    private void Start()
    {
        EventManager.current.onDialogueTriggerEvent += DialogueEvent;
    }
    private void DialogueEvent(string id)
    {
        if (id == "FadeIn")
        {
            direction = 1;
        }
        if (id == "FadeOut")
        {
            direction = -1;
        }
    }
    private void Update()
    {
        if (direction == 1)
            dir += Time.deltaTime;
        if (direction == -1)
            dir -= Time.deltaTime;
        fader.color = new Color(0, 0, 0, dir);
    }
}
