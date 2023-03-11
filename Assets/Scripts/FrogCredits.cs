/*
    FrogCredits.cs controls displaying the player name and high score.
*/
using UnityEngine;
using UnityEngine.UI;

public class FrogCredits : MonoBehaviour
{

    public Text PlayerNameText;
    public Text HighScoreText;

    // On start, set player name text to the value set in the main menu,
    // set the high score text to the value set in the level scene.
    void Start()
    {
        PlayerNameText.text = TitleUi.playerName;
        HighScoreText.text = "High Score: " + UiManager.highScore;
    }

}
