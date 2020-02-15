﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
 * This class should read in a text file and convert it into a dictionary 
 * [space => {[ship=>prefix],[star=>containing],[enter=>keys]}
 * Start game -> round 1 -> randomly select word from dictionary
 * get dictionary(value) linked to word and save it as a new dictionary
 * Choose random word in dictionary and get its value, set this value to new string = relation
 * Choose another random word and display this on screen
 * Check if word is put in related and check that in the dictionary it's value matches the relation
 * If true nothing happens, if false they lose a life
 * Remove word from dictionary
 * Continue until dictionary is empty. Add one to round tally(only 3 rounds should be done)
 */

public class Conext : MonoBehaviour
{
    public string relation = "";
    public List<string> relations = new List<string>();
    public int points = 0;
    public Dictionary<string, Dictionary<string, string>> words = new Dictionary<string, Dictionary<string, string>>();
    public TextMeshProUGUI displayedWord;
    public TextMeshProUGUI startWord;
    public TextMeshProUGUI pointsText;
    public Button relevant;
    public Button irrelevant;
    public bool selected = false;
    int rounds = 0;
    //dictionary words
    //string relation
    //int lives
    //dictionary temp words
    //static int points- needs to be accessed from other classes
    // Start is called before the first frame update
    void Start()
    {
        ReadInDictionary();
        StartCoroutine(ConextStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IsSelected() {
        if (selected)
        {
            selected = false;
        }
        else
        {
            selected = true;
        }
    }

    public void ReadInDictionary() {

        string path = "Assets/Resources/connections.txt";
        StreamReader whole = new StreamReader(path);
        while (true) {
            string line = whole.ReadLine();
            if (line==null) { break; }
            Dictionary<string, string> wordAndConnection = new Dictionary<string, string>();
            string[] topic = line.Split('=');
            relation = topic[0];//first element is identifier
            string[] connections = topic[1].Split(',');
            foreach (string s in connections) {
                string[] temp = s.Split('-');
                wordAndConnection.Add(temp[0], temp[1]);
            }
            words.Add(relation, wordAndConnection);
            relations.Add(relation);
            
        }
        whole.Close();
        //read in text as string
        //split first word separated by - -
        //take first word(key) and set string topic to that 
        //add the rest of the word to a temp dictionary, splitting by key and value
    }

    public IEnumerator ConextStart() {
        
        System.Random rand = new System.Random();
        int r = rand.Next(0,words.Count);
        string currentWord = relations[r];//the word we are finding connections for
        Dictionary<string, string> tempDict = words[currentWord];
        List<string> secrets = new List<string>();
        //Debug.Log("____NEW ROUND_____: " + currentWord);
        foreach (string s in tempDict.Values) {
            secrets.Add(s);
        }
        System.Random rand1 = new System.Random();
        int i = rand.Next(0, words.Count);
        string secretConnection = secrets[i];
        startWord.text = currentWord;
        foreach (string s in tempDict.Keys) {
            Debug.Log(secretConnection + "|" + tempDict[s]);
            displayedWord.text = s;//keys
            yield return new WaitUntil(()=>selected);
            IsSelected();
            CheckCorrect(tempDict, s, secretConnection);
            pointsText.text = points.ToString();
            
        }
        rounds++;
        if (rounds == 3)
        {
            SceneManager.LoadScene("Room");
        }
        else {
            StartCoroutine(ConextStart());
        }
            
        
       
        

    }

    public void CheckCorrect(Dictionary<string, string> tempDict, string s, string secretConnection) {
        if (RelevantOrIrrelevant.relevant == false) {
            if (tempDict[s] == secretConnection) {
                points--;
                return;
            }
        }

        if (RelevantOrIrrelevant.relevant == true) {
            if (tempDict[s] != secretConnection)
            {
                points--;
                return;
            }
        }
        points++;
    }
}
