using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    private float minDistance = 0.2f;
    private float range;

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
