using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpRewardController : MonoBehaviour
{

    GameObject prefab;
    GameObject rewards, info;
    private PlayerController player;

    private void OnEnable()
    {
        Time.timeScale = 0;
        this.prefab = Resources.Load<GameObject>("Prefabs/Reward");
        this.rewards = transform.Find("Rewards").gameObject;
        this.info = transform.Find("Info").gameObject;
        buildRewards();
        this.info.GetComponent<PlayerStatsController>().enable();
        this.player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnDisable()
    {
        removeRewards();
        Time.timeScale = 1;
    }

    private void buildRewards()
    {
        for (int i = 0; i < LevelUpRewardsSettings.NUMBER_REWARDS; i++)
        {
            LevelUpReward lvlUpReward = LevelUpRewardsManager.getReward();
            GameObject reward = Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
            reward.gameObject.transform.SetParent(rewards.gameObject.transform);
            reward.transform.Find("type").GetComponent<TMP_Text>().text = lvlUpReward.type.ToString();
            reward.transform.Find("value").GetComponent<TMP_Text>().text = "+" + lvlUpReward.value.ToString();
            reward.transform.Find("value").GetComponent<TMP_Text>().text = "+" + lvlUpReward.value.ToString();
            reward.transform.Find("sprite").GetComponent<Image>().sprite = lvlUpReward.sprite;
            reward.GetComponent<Button>().onClick.AddListener(delegate { clickHandler(lvlUpReward); });
        }
    }

    public void enable()
    {
        this.gameObject.SetActive(true);
    }

    public void disable()
    {
        this.gameObject.SetActive(false);
    }

    private void removeRewards()
    {
        foreach (Transform childs in rewards.transform)
        {
            Destroy(childs.gameObject);
        }
    }

    public void clickHandler(LevelUpReward reward)
    {
        switch (reward.type)
        {
            case LevelUpRewardType.Gold:
                //TODO: SISTEMA DE ORO
                break;
            case LevelUpRewardType.Regeneration:
                //playerHealthController.health += (int)reward.value;
                break;

            default:
                player.stats.upgradeStat((StatType)reward.type, reward.value);
                break;
        }
        disable();
    }
}
