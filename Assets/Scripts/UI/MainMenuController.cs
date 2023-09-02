using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject settingsMenu;

    [SerializeField]
    private GameObject recordsMenu;


    public void ButtonStartClick()
    {
        SceneManager.LoadScene("TestGame");
    }

    public void ButtonRecordsClick()
    {
        mainMenu.SetActive(false);
        recordsMenu.SetActive(true);
    }

    public void ButtonSettingsClick()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ButtonReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        recordsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ButtonExitClick()
    {
        Application.Quit();
    }

    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        recordsMenu.SetActive(false);
    }
}
