﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

    /*
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    
    private void Awake() {
        
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            //Bubble sort
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
                for (int j = 0; j < highscores.highscoreEntryList.Count; j++) {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
        
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer , highscoreEntryTransformList);
            
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformsList) {
        float templateHeight = 30f;
        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformsList.Count);
            entryTransform.gameObject.SetActive(true);
            int rank = i + 1;
            string rankString;
            switch (rank) {
                default: rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            int score = highscoreEntry.score;
            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
            string name = highscoreEntry.name;
            entryTransform.Find("nameText").GetComponent<Text>().text = name;
            //Change background line to odd positions
            entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
            if (rank == 1) {
                entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
                entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
                entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            }
            switch (rank) {
                default:
                    entryTransform.Find("trophy").gameObject.SetActive(false);
                    break;
                case 1:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.yellow;
                    break;
                case 2:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.grey;
                    break;
                case 3:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.cyan;
                    break;
            }
            transformsList.Add(entryTransform);
        }
    }
    public void AddHighscoreEntry(int score, string name) {
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    
    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }
    */
}