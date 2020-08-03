using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour
{
    [SerializeField] Transform[] Directions;
    public GameObject Block;
    public GameObject CarriedBlock;
    public bool canGrab = false;
    public void ChangeDirections(Vector2 dir)
    {
        if (dir[1] == 1)
        {
            gameObject.transform.position = Directions[0].position;
        }
        if (dir[1] == -1)
        {
            gameObject.transform.position = Directions[1].position;
        }
        if (dir[0] == 1)
        {
            gameObject.transform.position = Directions[2].position;
        }
        if (dir[0] == -1)
        {
            gameObject.transform.position = Directions[3].position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("butts");
        if (other.tag == "Block")
        {
            
            canGrab = true;
            Block = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Block)
        {
            canGrab = false;
        }
    }
    public void GrabTime(bool x)
    {
        if (x)
        {
            Block.GetComponent<Blocks>().OrderChange(x);
        }
        else
        {
            CarriedBlock.GetComponent<Blocks>().OrderChange(x);
        }
    }

}
