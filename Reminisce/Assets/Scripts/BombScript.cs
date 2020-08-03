using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bolt;

public class BombScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    Color[] bomb = { new Color(1, 1, 1), new Color(1, 0, 0) };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Boomtime");
    }
    IEnumerator Boomtime()
    {
        bool colour = false;
        float increment = 0.15f;
        for (float timer = 1; timer > 0; timer -= increment)
        {
            colour = !colour;
            sprite.color = bomb[System.Convert.ToInt32(colour)];
            yield return new WaitForSeconds(timer);
        }
        BOOM();
        yield return null;
    }
    public void BOOM()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        //explosion goes here
        StopCoroutine("Boomtime");
        Debug.Log(Convert.ToBoolean(Variables.Object(GameObject.Find("Player")).Get("HasBlock")));
        if (!Convert.ToBoolean(Variables.Object(GameObject.Find("Player")).Get("HasBlock")))
        {
            Variables.Object(GameObject.Find("Player")).Set("CanBomb", true);
        }
        
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("HIT");
            //apply damage
        }
    }
}
