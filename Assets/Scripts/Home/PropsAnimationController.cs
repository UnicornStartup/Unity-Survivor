using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsAnimationController : MonoBehaviour
{
    public float speed = 1f;
    private float rightPixel = 1;
    private float leftPixel = 1f;
    private float objectSize = 5f;
    private Vector3 spawn, target;

    void Start()
    {
        rightPixel = ScreenUtility.Instance.Right;
        leftPixel = ScreenUtility.Instance.Left;
        objectSize = gameObject.GetComponent<Collider2D>().bounds.size.x/2;

        spawn = new Vector3(rightPixel + objectSize, transform.position.y);
        target = new Vector3(leftPixel - objectSize, transform.position.y);

        transform.position = spawn;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (transform.position == target)
        {
            transform.position = spawn;
        }
    }
}
