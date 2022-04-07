using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawn(Vector3 position, Transform transform)
    {
        GameObject enemy = getEnemy(position, transform);
        EnemyCollection.addEnemy(enemy.GetComponent<EnemyController>());
        return enemy;
    }

    public GameObject getEnemy(Vector3 position, Transform transform)
    {
        EnemyController enemy = EnemyCollection.getDisabledEnemy();
        if (enemy == null)
        {
            return instantiateEnemy(position, transform);
        }
        enemy.setPosition(position).setTarget(transform).setStats(new Stats().setHealth(2).setDamage(2).setMoveSpeed(3).setSpeedAtack(2)).enable();

        return enemy.gameObject;
    }
    public GameObject instantiateEnemy(Vector3 position, Transform transform)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/Enemy");
        GameObject newEnemy = Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
        newEnemy.AddComponent<EnemyController>()
                .setTarget(transform)
                .setPosition(position)
                .setStats(new Stats().setHealth(2).setDamage(2).setMoveSpeed(3).setSpeedAtack(2))
                .setTileset("Bat")
                .setSprite("Bat_13")
                .enable();
        return newEnemy;
    }
}
