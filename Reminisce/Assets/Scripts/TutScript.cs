using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutScript : MonoBehaviour
{
    public Text text;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(Time.time) / 700);
        Color temp = new Color(1,1,1,1);
        float solidDist = 6.0f;
        float dist = Vector2.Distance( transform.position, player.position);

        if (dist < solidDist)
        {
            dist = solidDist;
        }
        temp.a = solidDist / dist;
        if (dist > 2 * solidDist)
        {
            temp.a = 0;
        }
            
        
        Debug.Log(temp.a);
        text.color = temp;
    }
}
