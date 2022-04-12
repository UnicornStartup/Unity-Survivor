using UnityEngine;

public class LevelUpRewardController : MonoBehaviour
{

    GameObject prefab;
    GameObject rewards, info;


    private void OnEnable()
    {

        this.prefab = Resources.Load<GameObject>("Prefabs/Reward");
        this.rewards = transform.Find("Rewards").gameObject;
        this.info = transform.Find("Info").gameObject;
        removeRewards();
        buildRewards();
    }

    private void buildRewards()
    {
        for (int i = 0; i < LevelUpRewardsSettings.NUMBER_REWARDS; i++)
        {
            LevelUpReward lvlUpReward = LevelUpRewardsManager.getReward();
            Debug.Log("type: " + lvlUpReward.type + " value: " + lvlUpReward.value);
            GameObject reward = Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
            reward.gameObject.transform.SetParent(rewards.gameObject.transform);
        }
    }

    private void removeRewards()
    {
        foreach (Transform childs in rewards.transform)
        {
            Destroy(childs.gameObject);
        }
    }

}
