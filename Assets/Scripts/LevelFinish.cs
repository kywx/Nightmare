using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    // bool just in case the player somehow triggers complete level() twice
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        // records scene completion. This has to be edited when we've made the hidden level and ending
        // perhaps something like: if (SceneManager.GetActiveScene().buildIndex = hidden level scene index) then PlayerPrefs.SetInt("isHiddenSceneComplete", 1), else
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (currentlevel >= PlayerPrefs.GetInt("scenesUnlocked"))
        {
            PlayerPrefs.SetInt("scenesUnlocked", currentlevel + 1);
        }

        // loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        levelCompleted = false;
    }
}
