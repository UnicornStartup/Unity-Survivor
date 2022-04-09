using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject spawn(Vector3 position, Transform transform)
    {
        BulletController bullet = getBullet(position, transform);
        BulletCollection.addBullet(bullet);
        return bullet.gameObject;
    }

    public BulletController getBullet(Vector3 position, Transform transform)
    {
        BulletController bullet = BulletCollection.getDisabledBullet();
        if (bullet == null)
        {
            return instantiateBullet(position, transform);
        }
        bullet = new BulletBuilder(bullet.gameObject)
            .setTarget(transform)
            .setPosition(position)
            .setTileset("fireball")
            .setSprite("fireball")
            .setDamage(2)
            .setSpeed(5)
            .build()
            .enable();

        return bullet;
    }
    public BulletController instantiateBullet(Vector3 position, Transform transform)
    {
        BulletController bullet = new BulletBuilder()
            .setTarget(transform)
            .setPosition(position)
            .setTileset("fireball")
            .setSprite("fireball")
            .setDamage(2)
            .setSpeed(5)
            .build()
            .enable();

        return bullet;
    }
}
