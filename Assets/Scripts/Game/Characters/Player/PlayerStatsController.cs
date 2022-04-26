using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsController : MonoBehaviour
{
    GameObject prefab;
    PlayerController playerController;

    void OnEnable()
    {
        removeStatsView();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        this.prefab = Resources.Load<GameObject>("Prefabs/Stat");
        buildStatsView();
    }

    public void buildStatsView()
    {
        Debug.Log(playerController.stats.stats.Count);
        foreach (Stat stat in playerController.stats.stats)
        {
            Debug.Log(stat.type);
            GameObject statGO = Instantiate(this.prefab, new Vector3(0, 0), Quaternion.identity);
            statGO.transform.Find("Image").GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            statGO.transform.Find("Value").GetComponent<TMP_Text>().text = stat.value.ToString();
            statGO.transform.SetParent(gameObject.transform);
        }
    }
    private void removeStatsView()
    {
        foreach (Transform childs in gameObject.transform)
        {
            Destroy(childs.gameObject);
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
}
