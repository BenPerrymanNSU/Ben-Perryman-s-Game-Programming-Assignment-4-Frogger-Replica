/*
    SaveReader.cs reads the high scores text document to display top 10 high scores on main menu and credits scenes.
*/
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveReader : MonoBehaviour
{

    public Text HighScoreList;
    public int Scores = 10;

    // On start trigger ShowScores with a delay, read high scores text document, 
    // split each text document line into 2 field arrays and combine them
    // together in the list text box until the counter reaches 10.
    void Start(){
        Invoke("ShowScores", 0.0000001f);
    }

    void ShowScores(){
        string savePath = "Assets/Saves/HighScores.txt";
        string line;
        string[] fields;
        int displayedScores = 0;

        HighScoreList.text = "";

        StreamReader reader = new StreamReader(savePath);
        while(!reader.EndOfStream && displayedScores < Scores){
            line = reader.ReadLine();
            fields = line.Split(':');
            HighScoreList.text += fields[0] + " : " + fields[1] + "\n";
            displayedScores += 1;
        }
        reader.Close();
    }
    
}
