using UnityEngine;

public class ShootController : MonoBehaviour
{
    private int damage;
    private float speedAtack;
    public SpawnBullet spawnBullet;
    private float timer = 0.0f;
    private float nextTime = 0;
    PlayerController playerController;

    void Start()
    {
        spawnBullet = GetComponent<SpawnBullet>();
        playerController = gameObject.GetComponent<PlayerController>();
        this.damage = playerController.stats.damage;
        this.speedAtack = playerController.stats.speedAtack;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= playerController.stats.speedAtack)
        {
            timer = timer - playerController.stats.speedAtack;
            GameObject closest = EnemyCollection.getClosed(transform);
            if (closest != null)
            {
                closest.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                spawnBullet.spawn(this.transform.position, closest.transform);
            }
        }
    }
}
