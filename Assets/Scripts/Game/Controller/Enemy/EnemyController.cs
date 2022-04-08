using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public Stats stats;
    public Sprite[] tileSet;
    private void Start()
    {
        gameObject.AddComponent<EnemyMoveController>();
        gameObject.AddComponent<HealthController>();
    }

    public EnemyController setStats(Stats stats)
    {
        this.stats = stats;
        return this;
    }

    public void enable()
    {
        gameObject.SetActive(true);
    }
    public EnemyController setTarget(Transform target)
    {
        this.target = target;
        return this;
    }
    public EnemyController setTileset(string nameCollection)
    {
        tileSet = Resources.LoadAll<Sprite>($"Sprites/Enemy/{nameCollection}");
        return this;
    }
    public EnemyController setSprite(string nameSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tileSet.Single(s => s.name == nameSprite);
        return this;
    }
    public EnemyController setPosition(Vector3 position)
    {
        gameObject.transform.position = position;
        return this;
    }
    public void disable()
    {
        gameObject.SetActive(false);
    }
}
