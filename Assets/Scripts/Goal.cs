/*
    Goal.cs is a script from the tutorial, controls what happens when the
    frog collides with the goal trigger.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public GameObject Frog;
    public Camera MainCamera;

    // On collision play clear sound, add 100 points to the current score,
    // disable frog's movement, collision, and pause functionality.
    // Calls the transition function with a 3 second delay.
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        UiManager.currentScore += 100;
        Frog.GetComponent<FrogMovement>().enabled = false;
        Frog.GetComponent<Collider2D>().enabled = false;
        MainCamera.GetComponent<FrogPause>().enabled = false;
        Invoke("Transition", 3.0f);
        }
    }

    // Reset's the current level scene.
    void Transition(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
