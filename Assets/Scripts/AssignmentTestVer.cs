using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentTestVer : MonoBehaviour
{
    
    /*
     * - Control accelration with input
     * - Give the player a max speed
     * - When no key is pressed slow down to a standstill motion **** DONE
     * - Use time.deltatime
     * 
     */


    Vector2 position;
    Vector2 velocity;
    Vector2 acceleration;
    Vector2 deceleration;

    public float speed = 2f;
    public float maxSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        //Control accelerations
        acceleration.x += Input.GetAxis("Horizontal") * Time.deltaTime;
        acceleration.y += Input.GetAxis("Vertical") * Time.deltaTime;

        //Control and give max speed;
        if(velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
       
        //apply the velocity to the players position
        position += velocity * Time.deltaTime;

        //apply the gravity to the players velocity.

        deceleration = -acceleration;
        //Deceleration
        if(Input.GetAxis("Horizontal") == 0)
        {
            velocity.x += deceleration.x * Time.deltaTime;
            if (velocity.x < 1 && velocity.x > -1)
            {
                velocity.x = 0;
                acceleration.x = 0;
            }
        }
        else
            velocity += acceleration * Time.deltaTime;

        if (Input.GetAxis("Vertical") == 0)
        {
            velocity.y += deceleration.y * Time.deltaTime;
            if (velocity.y < 1 && velocity.y > -1)
            {
                velocity.y = 0;
                acceleration.y = 0;
            }
        }
        else
            velocity += acceleration * Time.deltaTime;

        Debug.Log("Velocity: "+ velocity);
        Debug.Log("deceleration: " + deceleration);

        transform.position = position;
    }

    //flips the vector's direction
    public Vector2 Flip(Vector2 vector)
    {
        return vector *= -1;
    }
}
