using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelController : MonoBehaviour
{

    public TMP_Text text;
    public Slider slider;

    void Start()
    {
        loadComponents();
        text.text = "0";
    }

    void loadComponents()
    {
        slider = GetComponent<Slider>();

        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            if (child.name.Equals("t_level"))
            {
                Debug.Log("TRUE");
                text = child.GetComponent<TMP_Text>();
            }
        }
    }

}
