/*
    FrogMovement.cs is part of a script from the tutorial, controls the frogs movements.
*/
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;

    // checks for user input to move the frog.
    void Update(){
        if (Input.GetKeyDown(KeyCode.W)){
            rb2D.MovePosition(rb2D.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            rb2D.MovePosition(rb2D.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            rb2D.MovePosition(rb2D.position + Vector2.down);
        }
                else if (Input.GetKeyDown(KeyCode.D)){
            rb2D.MovePosition(rb2D.position + Vector2.right);
        }
    }

}
