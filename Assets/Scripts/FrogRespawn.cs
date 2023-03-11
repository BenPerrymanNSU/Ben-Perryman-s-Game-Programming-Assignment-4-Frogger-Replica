/*
    FrogRespawn.cs is part of a script from the tutorial, Controls the frog dieing
    and scene resetting for respawn.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogRespawn : MonoBehaviour
{

    public GameObject Frog;
    public Camera MainCamera;
    private SpriteRenderer SpriteRend;
    public Sprite FrogDead;

    public static float Lives = 3;
    public static bool isDead = false;
    private float respawnDelay = 2.5f;

    // On start, enable the frog's movement, collision, and pause
    // functionality, sets the frog's Sprite Renderer and resets
    // the death check.
    void Start(){
        isDead = false;
        Frog.GetComponent<FrogMovement>().enabled = true;
        Frog.GetComponent<Collider2D>().enabled = true;
        MainCamera.GetComponent<FrogPause>().enabled = true;
        SpriteRend = Frog.GetComponent<SpriteRenderer>();
    }

    // On collision with a car prefab or out-of-bounds wall trigger,
    // decrease lives counter if higher than 0, play death sound,
    // change sprite to dead sprite, sets the death check, disables
    // the frog's movement, collision, and pause functionality.
    // Triggers the Respawn function with a 2.5 second delay.
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Car" || col.tag == "Wall"){
            if (Lives > 0){
                Lives--;
            }
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            SpriteRend.sprite = FrogDead;
            isDead = true;
            Frog.GetComponent<FrogMovement>().enabled = false;
            Frog.GetComponent<Collider2D>().enabled = false;
            MainCamera.GetComponent<FrogPause>().enabled = false;
            Invoke("Respawn", respawnDelay);
        }
    }

    // Reloads level scene if the frog still has lives, otherwise continue to credits.
    void Respawn(){
        if (Lives > 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
