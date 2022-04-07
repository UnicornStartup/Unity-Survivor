using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage { set; get; } = 1000;
    public Transform target;

    public float speed { set; get; }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION" + other.gameObject.name);
        other.gameObject.GetComponent<HealthController>().damage(damage);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}