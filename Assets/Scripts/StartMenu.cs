using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("scenesUnlocked", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelSelectionMenu()
    {
        SceneManager.LoadScene(10);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
