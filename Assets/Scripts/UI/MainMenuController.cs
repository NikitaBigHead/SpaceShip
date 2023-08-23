using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ButtonStartClick()
    {
        SceneManager.LoadScene("TestGame");
    }

    public void ButtonRecordsClick()
    {

    }

    public void ButtonSettingsClick()
    {

    }

    public void ButtonExitClick()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
