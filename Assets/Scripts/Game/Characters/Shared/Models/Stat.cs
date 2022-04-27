using UnityEngine;

public class Stat
{
    public StatType type;
    public Sprite image;
    public float value;

    public Stat(StatType type, float value, bool hasImage)
    {
        this.type = type;
        this.value = value;

        if (hasImage)
        {
            this.image = Resources.LoadAll<Sprite>("Sprites/Icons/icons")[getImageId()];
        }
    }

    public int getImageId()
    {
        int value = 0;
        switch (type)
        {
            case StatType.AtackSpeed:
                value = 11;
                break;
            case StatType.Damage:
                value = 9;
                break;
            case StatType.MoveSpeed:
                value = 2;
                break;
            case StatType.Health:
                value = 4;
                break;
        }
        return value;
    }
}
