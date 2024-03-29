using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelController : MonoBehaviour
{

    public TMP_Text text;
    public Slider slider;
    public int experience;
    public int level;
    public LevelUpRewardController rewardController;

    void Start()
    {
        loadComponents();
        text.text = level.ToString();
        slider.maxValue = 100;
    }

    void loadComponents()
    {
        slider = GetComponent<Slider>();

        foreach (Transform child in transform)
        {
            if (child.name.Equals("t_level"))
            {
                text = child.GetComponent<TMP_Text>();
            }
        }
        rewardController = transform.parent.Find("LevelUp").GetComponent<LevelUpRewardController>();
    }

    public void add(int exp)
    {
        experience += exp;
        if (experience >= 100)
        {
            experience -= 100;
            level++;
            text.text = level.ToString();
            rewardController.enable();
        }
        slider.value = experience;
    }
}
