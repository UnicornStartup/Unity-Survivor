using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 currentPos;
    private Vector3 direction;

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
        BulletCollection.removeBullet(this.gameObject);
        gameObject.SetActive(false);
    }
}
