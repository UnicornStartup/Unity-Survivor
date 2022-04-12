using UnityEngine;

public class LevelUpReward
{
    public float value;
    public LevelUpRewardType type;
    public Sprite sprite;

    public LevelUpReward(float value, LevelUpRewardType type, Sprite sprite)
    {
        this.value = value;
        this.type = type;
        this.sprite = sprite;
    }
}
