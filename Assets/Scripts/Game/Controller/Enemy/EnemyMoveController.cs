using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private Transform target;
    private float speed;
    private float minDistance = 0.2f;
    private float range;
    private void Start()
    {
        target = GetComponent<EnemyController>().target;
        speed = GetComponent<EnemyController>().stats.moveSpeed;
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
