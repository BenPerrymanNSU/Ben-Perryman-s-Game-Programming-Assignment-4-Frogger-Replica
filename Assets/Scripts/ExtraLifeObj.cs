/*
    ExtraLifeObj.cs controls what happens when frog collides with extra life prefab.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeObj : MonoBehaviour
{

    public GameObject ExtraLife;

    // On collision with player, play collect sound, add a life is lives isn't full,
    // add to the player's score, and trigger the TrigDestroy function.
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            if (FrogRespawn.Lives < 3 && FrogRespawn.isDead != true){
                FrogRespawn.Lives++;
            }
            UiManager.currentScore += 50;
            Invoke("TrigDestroy", 0.12f);
        } 
    }

    // Finds the extra life prefab and destroys it.
    void TrigDestroy(){
        ExtraLife = GameObject.Find("ExtraLife");
        Destroy(ExtraLife);
    }
}
