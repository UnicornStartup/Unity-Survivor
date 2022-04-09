using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    public Transform target;
    public float speed;

    public void build(int speed, Transform target)
    {
        this.speed = speed;
        this.target = target;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
    }
}
