using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventScript : MonoBehaviour
{
    public Transform followLoc;
    public float speed;
    public Transform Destination;
    public void Awake()
    {
        Destination = followLoc;
    }
    public void Mover(Transform end)
    {
        Destination = end;
    }
    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Destination.position, speed * Time.deltaTime);
    }
}
