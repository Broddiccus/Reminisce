using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class KnightScript : MonoBehaviour
{
    public Animator visuals;
    public SpriteRenderer layering;
    public float range = 2.0f;
    public float speed;
    private float endTime = 1.0f;
    public int health = 10;
    private int attackState = 0;
    public enum KState {Idle,Attacking,Dead,Moving };
    public KState state = KState.Idle;
    private bool facing = false;
    private Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    public void AttackEvent()
    {
        visuals.SetBool("Attacking", false);
        visuals.SetBool("Moving", false);
        state = KState.Idle;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.position.x)
        {
            if (facing)
            {
                transform.Rotate(new Vector3(0, 180));
                facing = false;
            }
                
        }
        else
        {
            if (!facing)
            {
                transform.Rotate(new Vector3(0, 180));
                facing = true;
            }
        }
        if (transform.position.y > player.position.y)
        {
            layering.sortingOrder = 1;
        }
        else
        {
            layering.sortingOrder = 2;
        }
        switch (state)
        {
            case KState.Idle:
                
                endTime -= Time.deltaTime;
                if (endTime < 0)
                {
                    endTime = 1.0f;
                    state = KState.Moving;
                }
                break;
            case KState.Moving:
                visuals.SetBool("Moving", true);
                if (Vector2.Distance(transform.position,player.position) > range)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
                }
                if (Vector2.Distance(transform.position, player.position) <= range)
                {
                    visuals.SetBool("Moving", false);
                    state = KState.Attacking;
                    
                }
                break;
            case KState.Attacking:
                if (!visuals.GetBool("Attacking"))
                {
                    attackState++;
                    if (attackState > 3)
                    {
                        attackState = 1;
                    }
                    visuals.SetInteger("Attack", attackState);
                    visuals.SetBool("Attacking", true);
                }
                break;
            case KState.Dead:
                visuals.SetBool("Dead", true);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT");
        if (collision.tag == "Player")
        {
            var temp = collision.gameObject;
            CustomEvent.Trigger(temp, "Damaged");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;

        }
    }
}
