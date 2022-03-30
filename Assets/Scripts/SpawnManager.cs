using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int numObjects = 4;
    public GameObject prefab;

    int interval = 1;
    float nextTime = 0;
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
            GameObject newEnemy = Instantiate(prefab, pos, Quaternion.identity);
            newEnemy.GetComponent<EnemyController>().target = transform;
            enemys.Add(newEnemy.GetComponent<EnemyController>());
            }
            nextTime += interval;
        }
        enemys.UpdatePositions();
        EnemyController closest = enemys.FindClosest(transform.position);
        closest.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        Debug.Log(a);
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
