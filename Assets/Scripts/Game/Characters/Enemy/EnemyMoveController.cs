using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float minDistance; //= 0.2f;
    private float range;

    public void build(int speed, Transform target, float minDistance)
    {
        this.speed = speed;
        this.target = target;
        this.minDistance = minDistance;
    }

    void Update()
    {
        if (target != null)
        {
            range = Vector2.Distance(transform.position, target.position);
            if (range > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
