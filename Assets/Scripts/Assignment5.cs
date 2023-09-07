using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : MonoBehaviour
{
    Vector2 position;
    Vector2 velocity;
    float gravity = 0;
    public float speed = 2f;

    bool isG = false;
 
    // Update is called once per frame
    void Update()
    {

        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical") ;
        Vector2 move = new Vector2(hori, vert).normalized;

        velocity = move * speed;

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
        position +=  velocity * Time.deltaTime;

        BoundsCheck();
        transform.position = position;

    }

    void BoundsCheck()
    {
        //Problem screen wraping?? How?!
        float boundsY = 5;

        //y
        if (position.y < -boundsY + 0.5f)
        {
            velocity.y = -velocity.y * 1.75f * Time.deltaTime;
            position.y = -boundsY + 0.5f;
        }
        if (position.y > boundsY)
        {
            position.y = boundsY;
        }


        //x
        float boundsX = 9;
        if (position.x <= -boundsX)
        {
            position.x = 8.45f + 0.5f;
        }
        else if (position.x >= boundsX)
        {
            position.x = -8.45f - 0.5f;
        }

    }
}
