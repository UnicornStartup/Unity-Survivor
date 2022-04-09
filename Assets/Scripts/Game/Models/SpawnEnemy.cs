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
            .setSprite("Bat_13")
            .setHealth(2)
            .setDamage(2)
            .setMoveSpeed(2)
            .setSpeedAtack(0)
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
            .setSprite("Bat_13")
            .setHealth(2)
            .setDamage(2)
            .setMoveSpeed(2)
            .setSpeedAtack(0)
            .build()
            .enable();

        Instantiate(enemy.gameObject, new Vector3(0, 0), Quaternion.identity);
        return enemy;
    }
}
