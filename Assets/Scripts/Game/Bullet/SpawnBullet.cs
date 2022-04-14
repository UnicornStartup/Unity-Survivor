using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject spawn(Vector3 position, Transform transform, int damage)
    {
        BulletController bullet = getBullet(position, transform, damage);
        BulletCollection.addBullet(bullet);
        return bullet.gameObject;
    }

    public BulletController getBullet(Vector3 position, Transform transform, int damage)
    {
        BulletController bullet = BulletCollection.getDisabledBullet();
        if (bullet == null)
        {
            return instantiateBullet(position, transform, damage);
        }
        bullet = new BulletBuilder(bullet.gameObject)
            .setTarget(transform)
            .setPosition(position)
            .setTileset("fireball")
            .setSprite("fireball")
            .setDamage(damage)
            .setSpeed(5)
            .build()
            .enable();

        return bullet;
    }
    public BulletController instantiateBullet(Vector3 position, Transform transform, int damage)
    {
        BulletController bullet = new BulletBuilder()
            .setTarget(transform)
            .setPosition(position)
            .setTileset("fireball")
            .setSprite("fireball")
            .setDamage(damage)
            .setSpeed(5)
            .build()
            .enable();

        return bullet;
    }
}
