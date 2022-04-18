using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int numObjects = 100;
    public GameObject prefab;

    int interval = 2;
    float nextTime = 0;

    public SpawnEnemy spawnEnemy;
    public SpawnBullet spawnBullet;

    private void Start()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        spawnBullet = GetComponent<SpawnBullet>();
    }

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
            }
            nextTime += interval;

        }

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
