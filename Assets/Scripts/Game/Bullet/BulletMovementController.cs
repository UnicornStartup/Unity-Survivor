using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    public Transform target;
    public Transform oldTransform;
    public float speed;

    Vector3 currentPos;
    Vector3 direction;

    public void build(int speed, Transform target)
    {
        this.speed = speed;
        this.target = target;

    }
    private void Start()
    {
        currentPos = transform.position;
        direction = (target.position - currentPos).normalized;

    }

    void Update()
    {    
        transform.position += direction * Time.deltaTime * speed;
    }
    void OnBecameInvisible()
    {
        BulletCollection.removeBullet(GetComponent<BulletController>());
        gameObject.SetActive(false);
    }
}
