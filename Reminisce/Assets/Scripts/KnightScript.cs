using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class KnightScript : MonoBehaviour
{
    public Animator visuals;
    public bool battleStart = false;
    public SpriteRenderer layering;
    public float range = 2.0f;
    public float speed;
    public bool cooldown = false;
    private float endTime = 1.0f;
    public int health = 10;
    private int attackState = 0;
    public enum KState {Idle,Attacking,Dead,Moving,Hit };
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
    public void HitEvent()
    {
        visuals.SetBool("Hit", false);
        visuals.SetBool("Attacking", false);
        visuals.SetBool("Moving", false);
        state = KState.Idle;
    }
    public void DeadEvent()
    {
        visuals.SetBool("Dead", true);
        visuals.SetBool("Dying", false);
        visuals.SetBool("Hit", false);
        visuals.SetBool("Attacking", false);
        visuals.SetBool("Moving", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            state = KState.Dead;
        }
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
                if (endTime < 0 && battleStart)
                {
                    endTime = health/10;
                    state = KState.Moving;
                }
                break;
            case KState.Moving:
                visuals.SetBool("Moving", true);
                if (Vector2.Distance(transform.position,player.position) > range)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, (speed - (health/10)) * Time.deltaTime);
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
                if (!visuals.GetBool("Dead"))
                    visuals.SetBool("Dying", true);
                break;
            case KState.Hit:
                if (cooldown)
                {
                    health--;
                    cooldown = false;
                    visuals.SetBool("Hit", true);
                }
                
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
    
}
