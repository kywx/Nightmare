using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    //public GameObject levelSelectionPanel;
    public Button[] levelSelectionButtons;
    int scenesUnlocked;


    // Start is called before the first frame update
    void Start()
    {
        scenesUnlocked = PlayerPrefs.GetInt("scenesUnlocked", 1);
        Debug.Log(scenesUnlocked);
        // resets
        for (int i = 0; i < levelSelectionButtons.Length; i++)
        {
            levelSelectionButtons[i].interactable = false;
            levelSelectionButtons[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        // edge case
        if (scenesUnlocked > 8)
        {
            scenesUnlocked = 8;
        }
        // changes to what is unlocked
        for (int i = 0; i < scenesUnlocked; i++)
        {
            levelSelectionButtons[i].interactable = true;
            levelSelectionButtons[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void LoadLevel (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
