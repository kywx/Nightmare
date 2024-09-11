using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    public Image bgImage;
    public Image characterImage;
    public Text characterName;
    public Text dialogueArea;
    // public GameObject storySpace;

    // private Queue<StoryLine> lines;
    public float typingSpeed = 0.03f;



    public Queue<StoryLine> StartStory(Story story)
    {
        Queue<StoryLine> lines = new Queue<StoryLine>();

        foreach (StoryLine storyline in story.storyLines)
        {
            lines.Enqueue(storyline);
        }

        LoadNextLine(lines);
        return lines;
    }


    public void LoadNextLine(Queue<StoryLine> lines)
    {
        if (lines.Count == 0)
        {
            EndThisChapter();
            return;
        }

        StoryLine currentLine = lines.Dequeue();
 
        bgImage.sprite = currentLine.background.backgroundImage;
        characterImage.sprite = currentLine.character.image;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(StoryLine storyLine)
    {
        dialogueArea.text = "";
        foreach (char letter in storyLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndThisChapter()
    {
        // records scene completion
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        if (currentscene >= PlayerPrefs.GetInt("scenesUnlocked"))
        {
            PlayerPrefs.SetInt("scenesUnlocked", currentscene + 1);
        }

        // goes to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
