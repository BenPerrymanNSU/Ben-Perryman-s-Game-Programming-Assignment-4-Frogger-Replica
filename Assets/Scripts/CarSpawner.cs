/*
    CarSpawner.cs is a script from the tutorial, Controls the spawning of car prefabs.
*/
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnDelay = 1f;

    public GameObject car;

    public Transform[] spawnPoints;

    private float timeToSpawn = 1f;

    // On start, set delay to the value chosen on the main menu.
    void Start(){
        spawnDelay = TitleUi.SpawnSpeed;
    }

    // Spawn car prefabs whenever the delayed time has passed.
    void Update(){
        if (timeToSpawn <= Time.time){
            SpawnCar();
            timeToSpawn = Time.time + spawnDelay;
        }
    }

    // Spawns car prefabs at randomly chosen spawn point and set
    // them to move in the given direction.
    void SpawnCar(){
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }

}
