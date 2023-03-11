/*
    ExtraLifeSpawner.cs controls the spawning of extra life prefabs.
*/
using UnityEngine;

public class ExtraLifeSpawner : MonoBehaviour
{
    private bool allowSpawn;
    public GameObject extraLifePrefabs;
    private Bounds spawnArea;
    private GameObject player;

    // On start, find the bounds of the spawning box and begin spawning.
    // Triggers an extra life prefab to spawn.
    void Start () {
        spawnArea = this.GetComponent<BoxCollider2D>().bounds;
        SpawnExtraLives(allowSpawn);
        Invoke("spawnExtraLife", 0f);
    }

    // Allows extra life prefabs to spawn if the player is in the scene.
    public void SpawnExtraLives(bool allowSpawn) {
        if(allowSpawn) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.allowSpawn = allowSpawn;
    }

    // Spawns an extra life prefab at random position within the bounds of
    // the spawning area and renames the extra life prefab to remove clone.
    void spawnExtraLife() {
        var newExtraLife = Instantiate(extraLifePrefabs, randomSpawnPosition(), Quaternion.identity);
        newExtraLife.name = "ExtraLife";
    }
    
    // Selects a random set of cordinates within the bounds of the spawning
    // area.
    Vector3 randomSpawnPosition() {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float y = Random.Range(spawnArea.min.y, spawnArea.max.y);

        return new Vector2(x, y);
    }
}
