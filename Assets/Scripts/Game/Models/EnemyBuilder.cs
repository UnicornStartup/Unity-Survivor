using System.Linq;
using UnityEngine;

public class EnemyBuilder
{
    public Transform target;
    public Stats stats = new Stats();
    public Sprite[] tileSet;

    public GameObject enemy = new GameObject();

    public EnemyBuilder()
    {
        this.enemy.SetActive(false);
        this.enemy.AddComponent<EnemyController>();
        this.enemy.AddComponent<SpriteRenderer>();
        //this.enemy.AddComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = enemy.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(0.323822f, 0.2223973f);
        boxCollider.offset = new Vector2(0.0050477392f, 0.03725329f);
        boxCollider.isTrigger = true;
        this.enemy.transform.localScale = new Vector3(5, 4, 0);
    }
    public EnemyBuilder(GameObject enemy)
    {
        this.enemy = enemy;
    }

    public EnemyBuilder setTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    public EnemyBuilder setTileset(string nameCollection)
    {
        tileSet = Resources.LoadAll<Sprite>($"Sprites/Enemy/{nameCollection}");
        return this;
    }

    public EnemyBuilder setSprite(string nameSprite)
    {
        if (this.tileSet != null)
            enemy.GetComponent<SpriteRenderer>().sprite = tileSet.Single(s => s.name == nameSprite);

        return this;
    }

    public EnemyBuilder setPosition(Vector3 position)
    {
        this.enemy.transform.position = position;
        return this;
    }

    public EnemyBuilder setHealth(int health)
    {
        this.stats.health = health;
        return this;
    }
    public EnemyBuilder setDamage(int damage)
    {
        this.stats.damage = damage;
        return this;
    }

    public EnemyBuilder setMoveSpeed(int moveSpeed)
    {
        this.stats.moveSpeed = moveSpeed;
        return this;
    }

    public EnemyBuilder setSpeedAtack(int speedAtack)
    {
        this.stats.speedAtack = speedAtack;
        return this;
    }

    public EnemyController build()
    {
        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.stats = this.stats;
        controller.target = this.target;
        controller.tileSet = this.tileSet;

        this.enemy.AddComponent<EnemyMoveController>().build(controller.stats.moveSpeed, controller.target, 0.2f);
        this.enemy.AddComponent<HealthController>().build(controller.stats.moveSpeed, false);
        return controller;
    }
}
