using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLocMover : MonoBehaviour
{
    private int playerx;
    private int playery;
    public GameObject sprite;
    public Animator self;
    public Transform[] locations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sprite.transform.position = new Vector2(sprite.transform.position.x,sprite.transform.position.y + Mathf.Sin(Time.time)/700);
        playerx = GameObject.Find("Player").GetComponent<Animator>().GetInteger("Directionx");
        playery = GameObject.Find("Player").GetComponent<Animator>().GetInteger("Directiony");
        self.SetInteger("Directionx", playerx);
        self.SetInteger("Directiony", playery);
        Debug.Log(playerx);
        Debug.Log(playery);
        if (playerx == 1)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition,locations[3].localPosition,  0.01f);
        }
        if (playerx == -1)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition,locations[1].localPosition, 0.01f);
        }
        if (playery == -1)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition,locations[2].localPosition, 0.01f);
        }
        if (playery == 1)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, locations[0].localPosition, 0.01f);
        }
    }
}
