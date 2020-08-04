using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sprite[] portraits;
    public string[] names;
    [TextArea(3,10)]
    public string[] sentences;
    
}
