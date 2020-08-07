using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBody : MonoBehaviour
{
    public KnightScript self;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (self.state != KnightScript.KState.Hit)
            {
                self.cooldown = true;
                self.state = KnightScript.KState.Hit;
            }
            
            
        }
    }
}
