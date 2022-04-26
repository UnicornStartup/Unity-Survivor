using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float currentTime = 400f;

    public TextMeshProUGUI countdownText;
    public bool counting;

    // public TimerController(float startTime)
    // {
    //     currentTime = startTime;
    // }

    void Start()
    {
        counting = true;
    }
    void FixedUpdate()
    {
        currentTime = currentTime -1 * Time.fixedDeltaTime;
        countdownText.text = currentTime.ToString("0");
    }

    void changeState()
    {
        counting = counting == true ? false : true;
    }

    void addTime(float time)
    {
        currentTime = currentTime + time;
    }

    void decreaseTime(float time)
    {
        currentTime = currentTime - time;
    }
}
