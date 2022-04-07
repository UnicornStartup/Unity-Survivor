using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public GameObject containerSettings, containerButtons;
    void Start()
    {
        setupHome();
    }

    public void setupHome()
    {
        containerButtons.SetActive(true);
        containerSettings.SetActive(false);
    }

    public void opencontainerSettings()
    {
        containerButtons.SetActive(false);
        containerSettings.SetActive(true);
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
