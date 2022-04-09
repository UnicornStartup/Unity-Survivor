using UnityEngine;

public class ShootController : MonoBehaviour
{
    private int damage;
    private int speedAtack;
    private float nextTime = 0;
    public SpawnBullet spawnBullet;


    void Start()
    {
        spawnBullet = GetComponent<SpawnBullet>();
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        this.damage = playerController.stats.damage;
        this.speedAtack = playerController.stats.speedAtack;
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            GameObject closest = EnemyCollection.getClosed(transform);
            if (closest != null)
            {
                closest.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                spawnBullet.spawn(this.transform.position, closest.transform);
            }
            nextTime += speedAtack;
        }
    }
}
