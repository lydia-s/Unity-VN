using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InkTestingScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public Button buttonPrefab;
    public TextMeshProUGUI avatarName;
    public static string playerName = "";


    // Start is called before the first frame update
    void Start()
    {

        GameObject worldClock = GameObject.Find("WorldClock");
        worldClock.GetComponent<MessageLists>().LoadMessagesFromList(avatarName.text);//load messages when you enter
        story = new Story(inkJSON.text);
        story.variablesState["player_name"] = playerName;
        if (worldClock.GetComponent<MessageLists>().storyPositions.ContainsKey(avatarName.text))//check contains name
        {
            var savedState = worldClock.GetComponent<MessageLists>().storyPositions[avatarName.text];//retrieve story state using key

            story.state.LoadJson(savedState);
        }
        else {
            FirstPaths(avatarName.text);
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
        List<string> tags = story.currentTags;//get tags
        string tag = "";//tag to label message
        string name = avatarName.text;//name of contact
        string loadedText = "";//text to post
        GameObject worldClock = GameObject.Find("WorldClock");//where the MessageLists script is attached
        while (story.canContinue) {//while the story can continue
            loadedText = LoadStoryChunk();//gets a line of text
            tags = story.currentTags;//refresh tags
            if (tags.Count > 0)
            {
                tag = tags[0];//set tag to current tag
            }
            string[] messages = loadedText.Split('\n');
            foreach (string s in messages) {
                if (s!="") {
                    PostMessage(s, tag, name);
                }
                
            }
            var savedState = story.state.ToJson();
            worldClock.GetComponent<MessageLists>().SaveStoryState(name, savedState);

        }
        

        
        
        foreach (Choice choice in story.currentChoices)
        {
            
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);
            choiceButton.onClick.AddListener(delegate {
                ChooseStoryChoice(choice);//this method then calls refreshUI
                var savedState = story.state.ToJson();
                worldClock.GetComponent<MessageLists>().SaveStoryState(name, savedState);
            });
        }


    }
    public void PostMessage(string message, string tag, string name) {
        
        GameObject worldClock = GameObject.Find("WorldClock");
        gameObject.GetComponent<GenerateMessage>().CreateMessage(message, tag);//generate text message(box you see on screen)
        worldClock.GetComponent<MessageLists>().SaveMessageToList(message, tag, name);//save message to list(for loading later)
        

    }
    /**When we start before the player has made any decisions the first set of choices will be chosen
     * based on which characters' messaging screens are opened so that it can lead them down different
     * story paths(names will change, they are hardcoded for testing purposes)
     * 
     * */
    void ChooseFirstPath(Choice choice) {
        story.ChooseChoiceIndex(choice.index);
    }
    void FirstPaths(string name) {
        story.Continue();
        switch (name) {
            case "Helen":
                ChooseFirstPath(story.currentChoices[0]);
                
                break;
            case "John":
                ChooseFirstPath(story.currentChoices[1]);
                break;
            case "John1":
                ChooseFirstPath(story.currentChoices[2]);
                break;
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
        text = story.Continue();
        return text;
    }
}
