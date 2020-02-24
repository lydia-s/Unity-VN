using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Synonym : MonoBehaviour
{
    string relation = "";
    public List<string> words = new List<string>();
    public Dictionary<string, Dictionary<string, string>> wordsAndSyns = new Dictionary<string, Dictionary<string, string>>();
    public TextMeshProUGUI displayedWord;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    public TextMeshProUGUI points;
    public int score = 0;
    public static bool selected = false;
    public static string buttonText = "";
    Dictionary<string, string> tempDict;//contains synonyms for one word
    // Start is called before the first frame update
    void Start()
    {
        ReadInDictionary();
        StartCoroutine(StartRounds());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IsSelected()
    {
        if (selected)
        {
            selected = false;
        }
        else
        {
            selected = true;
        }
    }

    public void ReadInDictionary()
    {

        string path = "Assets/Resources/syns.txt";
        StreamReader whole = new StreamReader(path);
        while (true)
        {
            string line = whole.ReadLine();
            if (line == null) { break; }
            Dictionary<string, string> wordAndConnection = new Dictionary<string, string>();
            string[] topic = line.Split('=');
            relation = topic[0];//first element is identifier
            string[] connections = topic[1].Split(',');
            foreach (string s in connections)
            {
                string[] temp = s.Split('-');
                wordAndConnection.Add(temp[0], temp[1]);
            }
            wordsAndSyns.Add(relation, wordAndConnection);
            words.Add(relation);

        }
        whole.Close();
        //read in text as string
        //split first word separated by - -
        //take first word(key) and set string topic to that 
        //add the rest of the word to a temp dictionary, splitting by key and value
    }

    public void SynStart()
    {
        System.Random rand = new System.Random();
        int r = rand.Next(0, words.Count);
        string currentWord = words[r];//the word we are finding connections for
        tempDict = wordsAndSyns[currentWord];
        List<string> possibleSyns = new List<string>();
        foreach (string s in tempDict.Keys)
        {
            possibleSyns.Add(s);
        }
        option1.text = possibleSyns[0];
        option2.text = possibleSyns[1];
        option3.text = possibleSyns[2];
        option4.text = possibleSyns[3];
        displayedWord.text = currentWord;   
    }

    public IEnumerator StartRounds() {

        for (int i = 0; i <= 12; i++)
        {
            SynStart();
            yield return new WaitUntil(() => selected);
            IsSelected();
            if (tempDict[buttonText] == "true")
            {
                score++;
                points.text = score.ToString();
            }
            else {
                score--;
                points.text = score.ToString();
            }

        }
        SceneManager.LoadScene("Room");
    }
}