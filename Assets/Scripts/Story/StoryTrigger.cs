using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Background
{
    public Sprite backgroundImage;
}

[System.Serializable]
public class Character
{
    public string name;
    public Sprite image;
}

[System.Serializable]
public class StoryLine
{
    public Background background;
    public Character character;
    [TextArea(3,10)]
    public string line;
}

[System.Serializable]
public class Story
{
    public List<StoryLine> storyLines = new List<StoryLine>();    
}



public class StoryTrigger : StoryManager
{
    // public static StoryTrigger Instance;
    public Story story;
    private Queue<StoryLine> lines;

    void Start()
    {
        Debug.Log("Starts");
        lines = LoadStory();
    }

   public Queue<StoryLine> LoadStory()
    {
        return StartStory(story);
    }

    public void LoadNextPage()
    {
        Debug.Log("Load next line");
        LoadNextLine(lines);
    }
}

