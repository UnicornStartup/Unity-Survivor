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
        currentPos = transform.position;
        direction = (target.position - currentPos).normalized;

       

        transform.right = Vector3.Lerp(transform.right, target.position - currentPos, 1000 * Time.deltaTime);

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
