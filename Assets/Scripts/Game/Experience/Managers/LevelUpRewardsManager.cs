using System;

public class LevelUpRewardsManager
{
    private static System.Random random = new System.Random();

    public static LevelUpReward getReward()
    {
        Array values = Enum.GetValues(typeof(LevelUpRewardType));
        LevelUpRewardType randomType = (LevelUpRewardType)values.GetValue(random.Next(values.Length));
        float value = 0;

        switch (randomType)
        {
            case LevelUpRewardType.AtackSpeed:
                value = (float)random.NextDouble() * (LevelUpRewardsSettings.MAX_ATACK_SPEED - LevelUpRewardsSettings.MIN_ATACK_SPEED) + LevelUpRewardsSettings.MIN_ATACK_SPEED;
                break;
            case LevelUpRewardType.Damage:
                value = (float)random.NextDouble() * (LevelUpRewardsSettings.MAX_DAMAGE - LevelUpRewardsSettings.MIN_DAMAGE) + LevelUpRewardsSettings.MIN_DAMAGE;
                break;
            case LevelUpRewardType.Gold:
                value = (int)random.NextDouble() * (LevelUpRewardsSettings.MAX_GOLD - LevelUpRewardsSettings.MIN_GOLD) + LevelUpRewardsSettings.MIN_GOLD;
                break;
            case LevelUpRewardType.Health:
                value = (int)random.NextDouble() * (LevelUpRewardsSettings.MAX_HEALTH - LevelUpRewardsSettings.MIN_HEALTH) + LevelUpRewardsSettings.MIN_HEALTH;
                break;
            case LevelUpRewardType.Regeneration:
                value = (int)random.NextDouble() * (LevelUpRewardsSettings.MAX_REGENERATION - LevelUpRewardsSettings.MIN_REGENERATION) + LevelUpRewardsSettings.MIN_REGENERATION;
                break;
            case LevelUpRewardType.MoveSpeed:
                value = (float)random.NextDouble() * (LevelUpRewardsSettings.MAX_MOVE_SPEED - LevelUpRewardsSettings.MIN_MOVE_SPEED) + LevelUpRewardsSettings.MIN_MOVE_SPEED;
                break;
        }
        return new LevelUpRewardBuilder().setType(randomType).setValue(value).build();
    }
}
