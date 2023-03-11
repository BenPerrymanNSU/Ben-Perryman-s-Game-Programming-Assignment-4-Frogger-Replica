/*
    SaveWriter.cs edits the list of high scores, removing lower highscores to add new high scores to the arry of 10 high scores
*/
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class SaveWriter : MonoBehaviour
{
    public int numberOfScores = 10;

    // On start, if the player has 0 lives, read the high scores text document 
    // and split each player's name and high score into 2 field arrays.
    // While filling the write array's, if the player's current high score is 
    // larger than field[1], then add current player's name and high score to 
    // the respective positions in the write arrays. The lowest high score in 
    // the text document will be removed. Finally, create a new text document, 
    // fill with the 10 player's names and high score entries found in each
    // write array, replace old text document found through the path.
    public void Start(){
        string savePath = "Assets/Saves/HighScores.txt";
        string line;
        string[] fields;
        int numOfWrittenScores = 0;
        string newHighScoreName = TitleUi.playerName;
        string newHighScoreNum = UiManager.highScore.ToString();
        string[] writeHighScoreNames = new string[10];
        string[] writeHighScoreNums = new string[10];
        bool newWrittenScore = false;

        if (FrogRespawn.Lives == 0){
            StreamReader reader = new StreamReader(savePath);
            while (!reader.EndOfStream ) {
                line = reader.ReadLine();
                fields = line.Split(':');
                if (!newWrittenScore && numOfWrittenScores < numberOfScores) {
                    if(Convert.ToInt32(newHighScoreNum) > Convert.ToInt32(fields[1])) {
                        writeHighScoreNames[numOfWrittenScores] = newHighScoreName;
                        writeHighScoreNums[numOfWrittenScores] = newHighScoreNum;
                        newWrittenScore = true;
                        numOfWrittenScores += 1;
                    }
                }
                if(numOfWrittenScores < numberOfScores) {
                    writeHighScoreNames[numOfWrittenScores] = fields[0];
                    writeHighScoreNums[numOfWrittenScores] = fields[1];
                    numOfWrittenScores += 1;
                }
            }
            reader.Close();
            StreamWriter writer = new StreamWriter(savePath);
            for(int x = 0; x < numOfWrittenScores; x++) {
                writer.WriteLine(writeHighScoreNames[x] + ':' + writeHighScoreNums[x]);
            }
            writer.Close();
            AssetDatabase.ImportAsset(savePath);
            TextAsset asset = (TextAsset)Resources.Load("scores");
        }
    }
}


/*

Template for filling high scores text document:

Jeb : 1000
John : 900
Bog : 800
Hale : 700
Jerry : 600
Luke : 500
Dave : 400
Manny : 300
Kate : 200
Neb : 100
*/