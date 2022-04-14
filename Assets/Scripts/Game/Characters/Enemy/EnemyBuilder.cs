using System.Linq;
using UnityEngine;

public class EnemyBuilder
{
    public Transform target;
    public StatCollection stats = new StatCollection();
    public Sprite[] tileSet;

    public GameObject enemy;

    public EnemyBuilder()
    {
        enemy = new GameObject();
        this.enemy.SetActive(false);
        this.enemy.AddComponent<EnemyController>();
        this.enemy.AddComponent<SpriteRenderer>();
        this.enemy.AddComponent<ExperienceSpawnerController>();
        Rigidbody2D rigidbody2D = enemy.AddComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = enemy.AddComponent<BoxCollider2D>();
        rigidbody2D.gravityScale = 0;
        boxCollider.size = new Vector2(0.323822f, 0.2223973f);
        boxCollider.offset = new Vector2(0.0050477392f, 0.03725329f);
        boxCollider.isTrigger = false;
        this.enemy.transform.localScale = new Vector3(3, 3, 0);
        this.enemy.name = "Enemy";
        this.enemy.tag = "Enemy";
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

    public EnemyBuilder setStat(StatType type, float value)
    {
        this.stats.addStat(type, value);
        return this;
    }

    public EnemyController build()
    {
        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.stats = this.stats;
        controller.target = this.target;
        controller.tileSet = this.tileSet;

        if (this.enemy.TryGetComponent(out EnemyMoveController enemyMoveController))
            enemyMoveController.build((int)controller.stats.getvalue(StatType.MoveSpeed), controller.target, 0.2f);
        else this.enemy.AddComponent<EnemyMoveController>().build((int)controller.stats.getvalue(StatType.MoveSpeed), controller.target, 0.2f);

        if (this.enemy.TryGetComponent(out HealthController healthController))
            healthController.build((int)controller.stats.getvalue(StatType.Health), false);
        else this.enemy.AddComponent<HealthController>().build((int)controller.stats.getvalue(StatType.Health), false);

        return controller;
    }
}
