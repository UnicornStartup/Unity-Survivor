using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawn(Vector3 position, Transform transform)
    {
        EnemyController enemy = getEnemy(position, transform);
        EnemyCollection.addEnemy(enemy);
        return enemy.gameObject;
    }

    public EnemyController getEnemy(Vector3 position, Transform transform)
    {
        EnemyController enemy = EnemyCollection.getDisabledEnemy();
        if (enemy == null)
        {
            return instantiateEnemy(position, transform);
        }
        enemy = new EnemyBuilder(enemy.gameObject)
            .setTarget(transform)
            .setPosition(position)
            .setTileset("Bat")
            .setSprite("Bat_0")
            .setStat(StatType.Health, 80)
            .setStat(StatType.MoveSpeed, 3)
            .setStat(StatType.Damage, 100)
            .build()
            .enable();

        return enemy;
    }
    public EnemyController instantiateEnemy(Vector3 position, Transform transform)
    {
        EnemyController enemy = new EnemyBuilder()
            .setTarget(transform)
            .setPosition(position)
            .setTileset("Bat")
            .setSprite("Bat_0")
            .setStat(StatType.Health, 80)
            .setStat(StatType.MoveSpeed, 2)
            .setStat(StatType.Damage, 100)
            .build()
            .enable();

        return enemy;
    }
}
