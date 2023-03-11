/*
    UiManager.cs is specifically meant for use in level scenes, controls the score at
    the top of the screen and frog life meter.
*/
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static int currentScore = 0;
    public static int highScore = 0;

    public Text scoreText;
    public Image HP3;
    public Image HP2;
    public Image HP1;
    private Color originColor;

    // On start, save the original color of the first frog
    // meter icon, set the score text to appear, and trigger
    // the fixed update below to activate once at start.
    void Start(){
        originColor = HP1.color;
        scoreText.gameObject.SetActive(true);
        Invoke("FixedUpdate", 0f);
    }

    // Keeps score text updated as the player collects points,
    // saves current score as high score if larger than high score,
    // changes the frog icons in the frog life meter to represent
    // the number of lives remaining.
    void FixedUpdate(){
        scoreText.text = currentScore.ToString();
        if(FrogRespawn.Lives == 0){
            scoreText.gameObject.SetActive(false);
        }

        if (currentScore > highScore){
            highScore = currentScore;
        }

        if (FrogRespawn.Lives == 3){
            HP3.GetComponent<Image>().color = originColor;
            HP2.GetComponent<Image>().color = originColor;
            HP1.GetComponent<Image>().color = originColor;
        }
        else if (FrogRespawn.Lives == 2){
            HP3.GetComponent<Image>().color = Color.black;
            HP2.GetComponent<Image>().color = originColor;
            HP1.GetComponent<Image>().color = originColor;
        }
        else if (FrogRespawn.Lives == 1){
            HP3.GetComponent<Image>().color = Color.black;
            HP2.GetComponent<Image>().color = Color.black;
            HP1.GetComponent<Image>().color = originColor;
        }
        else if (FrogRespawn.Lives == 0){
            HP3.GetComponent<Image>().color = Color.black;
            HP2.GetComponent<Image>().color = Color.black;
            HP1.GetComponent<Image>().color = Color.black;
            UiManager.currentScore = 0;
        }
    }
}
