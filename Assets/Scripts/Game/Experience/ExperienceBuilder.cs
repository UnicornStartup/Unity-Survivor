using System.Linq;
using UnityEngine;

public class ExperienceBuilder
{
    private Sprite sprite;
    private int value;
    private Sprite[] tileSet;
    private GameObject experience;

    public ExperienceBuilder()
    {
        this.experience = new GameObject();
        this.experience.SetActive(false);
        this.tileSet = Resources.LoadAll<Sprite>($"Sprites/exp");
        this.experience.AddComponent<SpriteRenderer>();
        BoxCollider2D collider = this.experience.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1, 1);
        collider.isTrigger = true;
        this.experience.AddComponent<ExperienceController>();
        this.experience.name = "Experience";
        this.experience.tag = "Exp";
    }

    public ExperienceBuilder(GameObject experience)
    {
        // this.tileSet = this.experience.GetComponent<ExperienceController>().tileSet;
        this.experience = experience;
    }

    public ExperienceBuilder setPosition(Vector3 position)
    {
        this.experience.transform.position = position;
        return this;
    }

    public ExperienceBuilder setSprite(string nameSprite)
    {
        if (this.tileSet != null)
            this.experience.GetComponent<SpriteRenderer>().sprite = tileSet.Single(s => s.name == nameSprite);
        return this;
    }

    public ExperienceBuilder setValue(int value)
    {
        this.value = value;
        return this;
    }

    public ExperienceController build()
    {
        ExperienceController controller = this.experience.GetComponent<ExperienceController>();
        controller.sprite = this.sprite;
        controller.tileSet = this.tileSet;
        controller.value = this.value;
        return controller;
    }
}
