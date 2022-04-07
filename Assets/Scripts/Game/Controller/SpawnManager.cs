using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int numObjects = 1;
    public GameObject prefab;

    int interval = 4;
    float nextTime = 0;

    public SpawnEnemy spawnEnemy;

    private void Start()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
    }

    KdTree<EnemyController> enemys = new KdTree<EnemyController>();
    void Update()
    {
        if (Time.time >= nextTime)
        {
            Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 30;
            Vector3 pos = RandomCircle(center, 10.0f, a);
                spawnEnemy.spawn(pos, transform);
            //GameObject newEnemy = Instantiate(prefab, new Vector3(0,0), Quaternion.identity);
            //newEnemy.AddComponent<EnemyController>()
            //        .setTarget(transform)
            //        .setPosition(pos)
            //        .setStats(new Stats().setHealth(2).setDamage(2).setMoveSpeed(3).setSpeedAtack(2))
            //        .setTileset("Bat")
            //        .setSprite("Bat_13")
            //        .enable();          
            //enemys.Add(newEnemy.GetComponent<EnemyController>());
            }
            nextTime += interval;
        }
        enemys.UpdatePositions();
        EnemyController closest = enemys.FindClosest(transform.position);
        if(closest != null)
        closest.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
