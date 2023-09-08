using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AssignmentOtherChar : MonoBehaviour
{

    /*
     * - Control accelration with input for both axis
     * - Give the player a max speed in a simplified manner
     * - When no input is detected slow down(decelerate) to a standstill motion
     * - Use time.deltatime
     * 
     * Extra
     * - Set bounds
     * - make screen wrapping
     * - add gravity when g is pressing g.
     */

    public float speed = 2f;
    public float maxSpeed = 5;

    private Vector2 velocity;
    public Vector2 pos ;
    float gravity = 0;

    bool isG = false;

    int health = 3;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontalInput, verticalInput).normalized;

        //  gravity
        Vector2 acceleration = move * speed;

        // deceleration when there's no input
        if (move == Vector2.zero)
        {
            Vector2 deceleration = -velocity.normalized * speed;
            velocity += deceleration * Time.deltaTime;

            if (velocity.sqrMagnitude < 0.1f * 0.1f)
            {
                velocity = Vector2.zero;
            }
        }
        else
            velocity += acceleration * Time.deltaTime;

        // clamp velocity to maxSpeed
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);


        if (Input.GetKeyDown(KeyCode.G) && !isG)
        {
            gravity = 9.8f;
            isG = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && isG)
        {
            gravity = 0;
            isG = false;
        }

        velocity.y -= gravity;

        BoundsCheck();
        // apply velocity to the position and position to the player.
        pos += velocity * Time.deltaTime;
        transform.position = pos;

    }


    void BoundsCheck()
    {
        float boundsY = 5;

        //y
        if (pos.y < -boundsY + 0.5f)
        {
            velocity.y = -velocity.y * 1.75f * Time.deltaTime;
            pos.y = -boundsY + 0.5f;
        }
        if (pos.y > boundsY)
        {
            pos.y = boundsY;
        }


        //x
        float boundsX = 9;
        if (pos.x <= -boundsX)
        {
            pos.x = 8.45f + 0.5f;
        }
        else if (pos.x >= boundsX)
        {
            pos.x = -8.45f - 0.5f;
        }
    }

    //Just for the excitment of things
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        Death();
        
    }
    void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

}
