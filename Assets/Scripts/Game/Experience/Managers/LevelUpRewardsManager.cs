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
            case LevelUpRewardType.MoveSpeed:
                value = (float)random.NextDouble() * (LevelUpRewardsSettings.MAX_MOVE_SPEED - LevelUpRewardsSettings.MIN_MOVE_SPEED) + LevelUpRewardsSettings.MIN_MOVE_SPEED;
                break;
            case LevelUpRewardType.Gold:
                value = random.Next(LevelUpRewardsSettings.MIN_GOLD, LevelUpRewardsSettings.MAX_GOLD);
                break;
            case LevelUpRewardType.Health:
                value = random.Next(LevelUpRewardsSettings.MIN_HEALTH, LevelUpRewardsSettings.MAX_HEALTH);
                break;
            case LevelUpRewardType.Regeneration:
                value = random.Next(LevelUpRewardsSettings.MIN_REGENERATION, LevelUpRewardsSettings.MAX_REGENERATION);
                break;
        }
        return new LevelUpRewardBuilder().setType(randomType).setValue(value).build();
    }
}
