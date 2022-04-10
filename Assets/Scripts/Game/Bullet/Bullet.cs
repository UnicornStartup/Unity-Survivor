using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage { set; get; } = 2;
    public Transform target;

    public float speed { set; get; }

    private void OnCollisionEnter2D(Collision2D other)
    {

        other.gameObject.GetComponent<HealthController>().damage(damage);

        BulletCollection.removeBullet(GetComponent<BulletController>());
        gameObject.SetActive(false);
    }
}
