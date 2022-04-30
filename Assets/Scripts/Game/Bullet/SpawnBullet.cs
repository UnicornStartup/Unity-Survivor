using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject spawn(Vector3 position, Transform transform, int damage)
    {
        GameObject bullet = getBullet(position, transform, damage);
        BulletCollection.addBullet(bullet);
        return bullet.gameObject;
    }

    public GameObject getBullet(Vector3 position, Transform transform, int damage)
    {
        GameObject bullet = BulletCollection.getDisabledBullet();
        if (bullet == null)
        {
            return instantiateBullet(position, transform, damage);
        }
        bullet = new BulletBuilder(bullet.gameObject)
            .setTarget(transform)
            .setPosition(position)
            .setTileset("Fireball")
            .setSprite("Fire-ball_0")
            .setDamage(damage)
            .setSpeed(5)
            .enable()
            .build();

        return bullet;
    }
    public GameObject instantiateBullet(Vector3 position, Transform transform, int damage)
    {
        GameObject bullet = new BulletBuilder()
            .setTarget(transform)
            .setPosition(position)
            .setTileset("Fireball")
            .setSprite("Fire-ball_0")
            .setDamage(damage)
            .setSpeed(5)
            .enable()
            .build();

        return bullet;
    }
}
