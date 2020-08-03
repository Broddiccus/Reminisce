using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public SpriteRenderer order;
    public void OrderChange(bool x)
    {
        if (x)
        {
            order.sortingLayerName = "Blocks";
        }
        else
        {
            order.sortingLayerName = "Default";
        }
    }
}
