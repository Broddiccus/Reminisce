using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventScript : MonoBehaviour
{
    public float speed;
    public void Mover(Transform end)
    {
        StopAllCoroutines();
        StartCoroutine("MoveCam", end);
    }
    IEnumerator MoveCam(Transform end)
    {
        float dist = Vector2.Distance(transform.position, end.position);
        while (dist > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, end.position, speed * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
