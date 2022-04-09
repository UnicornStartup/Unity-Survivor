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
        this.bullet.AddComponent<Bullet>();
        this.bullet.AddComponent<BulletMovementController>();
        this.bullet.name = "Bullet";
        this.bullet.tag = "Bullet";

        CircleCollider2D colider = bullet.AddComponent<CircleCollider2D>();
        colider.radius = 4;
        colider.isTrigger = false;
        this.bullet.transform.localScale = new Vector3(0.1f, 0.1f);
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
        tileSet = Resources.LoadAll<Sprite>($"Sprites/{nameCollection}");
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

    public BulletController build()
    {
        BulletController controller = bullet.GetComponent<BulletController>();
        controller.damage = this.damage;
        controller.speed = this.speed;
        controller.target = this.target;
        controller.tileSet = this.tileSet;
        this.bullet.GetComponent<BulletMovementController>().build(controller.speed, controller.target);
        return controller;
    }
}
