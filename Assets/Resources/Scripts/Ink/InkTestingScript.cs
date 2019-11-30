using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkTestingScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public Text textPrefab;
    public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        if (PlayerPrefs.HasKey("inkSaveState"))
        {
            var savedState = PlayerPrefs.GetString("inkSaveState");
            story.state.LoadJson(savedState);
        }
        RefreshUI();
        

    }
    public void ResetState()
    {
        story.ResetState();
        
    }

    public void RefreshUI()
    {
        EraseUI();
        Text storyText = Instantiate(textPrefab) as Text;

        string text = LoadStoryChunk();

        List<string> tags = story.currentTags;
        string tag = "";
        if (tags.Count > 0)
        {
            tag = tags[0];
        }

        storyText.text = text;
        
        storyText.transform.SetParent(this.transform, false);
        
        foreach (Choice choice in story.currentChoices)
        {
            
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            choiceButton.transform.SetParent(this.transform, false);
            choiceButton.onClick.AddListener(delegate {
                ChooseStoryChoice(choice);
                gameObject.GetComponent<GenerateMessage>().CreateMessage(storyText.text.Replace("\n", string.Empty), tag);
                var savedState = story.state.ToJson();
                PlayerPrefs.SetString("inkSaveState", savedState);
            });
        }


    }

    void ChooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    void EraseUI()
    {
        for (int i = 0; i< this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

    }



    string LoadStoryChunk()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        
        return text;
    }
}
