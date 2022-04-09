using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public Stats stats;
    public Sprite[] tileSet;
    public LevelController level;
    private void Start()
    {
        gameObject.AddComponent<PlayerMovementController>();
        gameObject.AddComponent<ShootController>();
        gameObject.AddComponent<SpawnBullet>();
        level = GameObject.Find("Canvas/Level").GetComponent<LevelController>();
    }

    public PlayerController setStats(Stats stats)
    {
        this.stats = stats;
        return this;
    }
    public PlayerController setTileset(string nameCollection)
    {
        tileSet = Resources.LoadAll<Sprite>($"Sprites/Character/{nameCollection}");
        return this;
    }
    public PlayerController setSprite(string nameSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tileSet.Single(s => s.name == nameSprite);
        return this;
    }

    public void addExp(int value)
    {
        Debug.Log("asd");
        level.add(value);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Exp")
        {
            ExperienceController experienceController = other.gameObject.GetComponent<ExperienceController>();
            addExp(experienceController.value);
            experienceController.disable();
        }
    }
}
