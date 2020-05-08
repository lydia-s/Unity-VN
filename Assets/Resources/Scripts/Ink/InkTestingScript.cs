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
    string savedState= "";
    public GameObject worldClock;

    // Start is called before the first frame update
    void Start()
    {

        worldClock = FindClock();//where the MessageLists script is attached
        worldClock.GetComponent<MessageLists>().LoadMessagesFromList(avatarName.text);//load messages when you enter
        story = new Story(inkJSON.text);
        story.variablesState["player_name"] = playerName;//set player name
        worldClock.GetComponent<MessageLists>().playerName = playerName;
        if (worldClock.GetComponent<MessageLists>().storyPositions.ContainsKey(avatarName.text))//check contains name
        {
            savedState = worldClock.GetComponent<MessageLists>().storyPositions[avatarName.text];//retrieve story state using key
            story.state.LoadJson(savedState);
            StartCoroutine(RefreshUI());
        }
        else {
            StartCoroutine(RefreshUI());
        }  
    }
    public GameObject FindClock() {
        GameObject worldClock = GameObject.Find("WorldClock");

        return worldClock;
    }
    public void ResetState()
    {
        story.ResetState();
    }

    public IEnumerator RefreshUI()
    {
        List<string> tags = story.currentTags;//get tags
        string tag = "";//tag to label message
        string name = avatarName.text;//name of contact
        string loadedText = "";//text to post
        //if (!story.canContinue) {//this is in case you leave the scene without making a choice, you will have the same choices displayed when you return
        //    DisplayChoices();
        //    yield break;
        //}
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
                   // Debug.Log(loadedText + story.canContinue.ToString());
                    savedState = story.state.ToJson();
                    worldClock.GetComponent<MessageLists>().SaveStoryState(name, savedState);
                    PostMessage(s, tag, name);
                    yield return new WaitUntil(() => GenerateMessage.posted);
                    GenerateMessage.posted = false;
                }
                
            }
            
        }
        
        DisplayChoices();
        
    }

    public void DisplayChoices() {
        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);
            choiceButton.onClick.AddListener(delegate {
                ChooseStoryChoice(choice);//this method then calls refreshUI
                worldClock.GetComponent<MessageLists>().SaveStoryState(name, savedState);
                savedState = story.state.ToJson();
                EraseUI();//this must execute after you make a choice
                Clock.timeSinceLastChoice = 0;
            });
        }
    }
    public void PostMessage(string message, string tag, string name) {
        GameObject worldClock = GameObject.Find("WorldClock");
        gameObject.GetComponent<GenerateMessage>().CreateMessage(message, tag);//generate text message(box you see on screen)
        worldClock.GetComponent<MessageLists>().SaveMessageToList(message, tag, name);//save message to list(for loading later)
    }
    

    void ChooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        StartCoroutine(RefreshUI());
    }

    void EraseUI()
    {
        for (int i = 0; i< this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    /*
     * Load a line of the story
     */
    string LoadStoryChunk()
    {
        string text = "";
        text = story.Continue();
        return text;
    }
}
