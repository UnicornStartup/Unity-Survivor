using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform target;
    public Sprite[] tileSet;
    public int damage;
    public int speed;

    public void build(Transform target, Sprite[] tileSet, int damage, int speed)
    {
        this.target = target;
        this.tileSet = tileSet;
        this.damage = damage;
        this.speed = speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<HealthController>().damage(damage);
        BulletCollection.removeBullet(this.gameObject);
        gameObject.SetActive(false);
    }
}
