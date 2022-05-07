using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;

    public int numObjects = 6;
    public int angleStartSpawn = 0;
    public int angleDistanceAumenton = 10;
    public float waitTime = 2.0f;

    private float timer = 0.0f;

    public SpawnEnemy spawnEnemy;
    public SpawnBullet spawnBullet;

    private void Start()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        spawnBullet = GetComponent<SpawnBullet>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Vector3 center = transform.position;
            for (int i = angleStartSpawn; i < numObjects + angleStartSpawn; i++)
            {
                int a = i * angleDistanceAumenton;
                Vector3 pos = RandomCircle(center, 10.0f, a);
                spawnEnemy.spawn(pos, transform);
            }
            timer = timer - waitTime;
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
