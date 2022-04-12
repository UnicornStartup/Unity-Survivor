
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
        //TODO: LoaaResource
        return new LevelUpReward(value, type, sprite);
    }
}
