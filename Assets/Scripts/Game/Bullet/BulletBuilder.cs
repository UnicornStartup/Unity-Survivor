using System.Linq;
using UnityEngine;

public class BulletBuilder
{
    public Transform target;
    public Sprite[] tileSet;
    public GameObject bullet;
    public int damage;
    public int speed;

    public BulletBuilder()
    {
        bullet = new GameObject();
        this.bullet.SetActive(false);
        this.bullet.AddComponent<SpriteRenderer>();
        this.bullet.AddComponent<BulletController>();
        this.bullet.AddComponent<BulletMovementController>();
        Animator animator = this.bullet.AddComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Anim/Bullet/Fireball/Bullet");
        this.bullet.name = "Bullet";
        this.bullet.tag = "Bullet";

        CircleCollider2D colider = bullet.AddComponent<CircleCollider2D>();
        colider.radius = 0.3f;
        colider.isTrigger = false;
        this.bullet.transform.localScale = new Vector3(1f, 1f);
    }
    public BulletBuilder(GameObject bullet)
    {
        this.bullet = bullet;
    }

    public BulletBuilder setTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    public BulletBuilder setTileset(string nameCollection)
    {
        tileSet = Resources.LoadAll<Sprite>($"Sprites/Bullets/{nameCollection}");
        return this;
    }
    public BulletBuilder setSprite(string nameSprite)
    {
        if (this.tileSet != null)
            bullet.GetComponent<SpriteRenderer>().sprite = tileSet.Single(s => s.name == nameSprite);

        return this;
    }

    public BulletBuilder setPosition(Vector3 position)
    {
        this.bullet.transform.position = position;
        return this;
    }

    public BulletBuilder setDamage(int damage)
    {
        this.damage = damage;
        return this;
    }

    public BulletBuilder setSpeed(int speed)
    {
        this.speed = speed;
        return this;
    }

    public BulletBuilder enable()
    {
        bullet.SetActive(true);
        return this;
    }

    public BulletBuilder disable()
    {
        bullet.SetActive(false);
        return this;
    }

    public GameObject build()
    {
        BulletController controller = bullet.GetComponent<BulletController>();
        controller.build(this.target, this.tileSet, this.damage, this.speed);
        this.bullet.GetComponent<BulletMovementController>().build(controller.speed, controller.target);
        return this.bullet;
    }
}
