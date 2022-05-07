using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public GameObject containerSettings, containerButtons;
    void Start()
    {
        containerButtons.SetActive(true);
        containerSettings.SetActive(false);
        gameObject.AddComponent<SoundManager>();
        
    }

    public void setupHome()
    {
        SoundManager.Instance.PlayButtonClick();
        containerButtons.SetActive(true);
        containerSettings.SetActive(false);
    }

    public void opencontainerSettings()
    {
        SoundManager.Instance.PlayButtonClick();
        containerButtons.SetActive(false);
        containerSettings.SetActive(true);
    }
    public void startGame()
    {
        SoundManager.Instance.PlayButtonClick();
        SceneManager.LoadScene("Game");
    }
}
