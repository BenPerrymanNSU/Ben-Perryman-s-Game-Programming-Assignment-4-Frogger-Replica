/*
    Car.cs is a script from the tutorial, it controls car prefab stats, movement, and despawning.
*/
using UnityEngine;

public class Car : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public GameObject car;

    public float carMinSpeed = 6f;
    public float carMaxSpeed = 12f;
    float carSpeed = 1f;

    // On start, set car prefab min/max speed and tie the range to a value.
    void Start(){
        carMinSpeed = carMinSpeed + TitleUi.CarSpeed;
        carMaxSpeed = carMaxSpeed + TitleUi.CarSpeed;
        carSpeed = Random.Range(carMinSpeed, carMaxSpeed);
    }

    // Sets the car prefab's forward movement with random speed.
    void FixedUpdate(){
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb2D.MovePosition(rb2D.position + forward * Time.fixedDeltaTime * carSpeed);
    }

    // On collision with invisble out-of-bound triggers delete car prefab.
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "CarDestroyer"){
            Destroy(car);
        }
    }

    // If the car makes it past the invisible trigger delete car prefab.
    void OnBecameInvisible(){
        Destroy(car);
    }

}
