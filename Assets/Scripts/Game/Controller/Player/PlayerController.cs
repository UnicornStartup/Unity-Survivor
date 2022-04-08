using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public Stats stats;
    public Sprite[] tileSet;
    private void Start()
    {
        gameObject.AddComponent<PlayerMovementController>();
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

}
