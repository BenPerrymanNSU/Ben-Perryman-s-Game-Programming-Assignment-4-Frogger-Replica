/*
    FrogPause.cs controls the pause functionality during level scenes.
*/
using UnityEngine;
using UnityEngine.UI;

public class FrogPause : MonoBehaviour
{
    public Text scoreText;
    public Text PauseText;
    public Image HP3;
    public Image HP2;
    public Image HP1;
    public Image PauseBackground;
    public Button MenuButton;
    public Button QuitButton;

    private bool Paused = false;

    // Checks if the escape key has been pressed and pauses
    // if pressed then unpauses when pressed again.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses all objects in the scene, disables gameplay ui 
    // elements and enables pause menu ui elements.
    void PauseGame()
    {
        Time.timeScale = 0;
        
        Paused = true;
        scoreText.gameObject.SetActive(false);
        HP3.gameObject.SetActive(false);
        HP2.gameObject.SetActive(false);
        HP1.gameObject.SetActive(false);
        PauseBackground.gameObject.SetActive(true);
        PauseText.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }

    // Resumes all object movements in the scene, disables pause
    // menu ui elements and enables gameplay ui elements.
    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        Paused = false;
        scoreText.gameObject.SetActive(true);
        HP3.gameObject.SetActive(true);
        HP2.gameObject.SetActive(true);
        HP1.gameObject.SetActive(true);
        PauseBackground.gameObject.SetActive(false);
        PauseText.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
    }
}
