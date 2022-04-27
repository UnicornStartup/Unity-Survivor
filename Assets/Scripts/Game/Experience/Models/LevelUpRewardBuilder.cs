
using System;
using UnityEngine;

public class LevelUpRewardBuilder
{
    public float value;
    public LevelUpRewardType type;
    public Sprite sprite;

    public LevelUpRewardBuilder() { }

    public LevelUpRewardBuilder setType(LevelUpRewardType type)
    {
        this.type = type;
        return this;
    }

    public LevelUpRewardBuilder setValue(float value)
    {
        this.value = (float)Math.Round(value, 1);
        return this;
    }

    public LevelUpReward build()
    {
        sprite = Resources.LoadAll<Sprite>("Sprites/Icons/icons")[getImageId()];

        return new LevelUpReward(value, type, sprite);
    }

    public int getImageId()
    {
        int value = 0;
        switch (type)
        {
            case LevelUpRewardType.AtackSpeed:
                value = 11;
                break;
            case LevelUpRewardType.Damage:
                value = 9;
                break;
            case LevelUpRewardType.MoveSpeed:
                value = 2;
                break;
            case LevelUpRewardType.Gold:
                value = 0;
                break;
            case LevelUpRewardType.Health:
                value = 4;
                break;
            case LevelUpRewardType.Regeneration:
                value = 12;
                break;
        }
        return value;
    }
}
