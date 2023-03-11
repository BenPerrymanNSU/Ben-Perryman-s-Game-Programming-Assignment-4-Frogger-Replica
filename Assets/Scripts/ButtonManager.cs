/*
    ButtonManager.cs controls the play button on the main menu, main menu and quit button on the level pause menu,
    and same for the credits scene.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    // Loads the next scene in the build list.
    public void NextScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Returns to the main menu scene, resets lives, pause, score, and high score.
    public void ScreenReturn(){
        FrogRespawn.Lives = 3;
        Time.timeScale = 1;
        UiManager.currentScore = 0;
        UiManager.highScore = 0;
        SceneManager.LoadScene(0);
    }

    // Exits the unity editor play window.
    public void QuitGame(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
