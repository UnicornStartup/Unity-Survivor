using UnityEngine;

public class Stat
{
    public StatType type;
    public Sprite image;
    public float value;

    public Stat(StatType type, Sprite image, float value)
    {
        this.type = type;
        this.image = image;
        this.value = value;
    }
}
