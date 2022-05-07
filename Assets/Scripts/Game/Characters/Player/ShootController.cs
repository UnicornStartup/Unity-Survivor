using UnityEngine;

public class ShootController : MonoBehaviour
{
    public SpawnBullet spawnBullet;
    private float timer = 0.0f;
    PlayerController playerController;

    void Start()
    {
        spawnBullet = GetComponent<SpawnBullet>();
        playerController = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= playerController.stats.getvalue(StatType.AtackSpeed))
        {
            timer = timer - playerController.stats.getvalue(StatType.AtackSpeed);
            GameObject closest = EnemyCollection.getClosed(transform);
            if (closest != null)
            {
                closest.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                spawnBullet.spawn(this.transform.position, closest.transform, (int)playerController.stats.getvalue(StatType.Damage));
                SoundManager.Instance.PlayShoot();
            }
        }
    }
}
